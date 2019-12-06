using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CefBrowserTool

{
    public partial class Form1 : Form
    {
        public ChromiumWebBrowser chromeBrowser;
        string defaultURL = $"http://{Environment.MachineName}:8037/"; 

        public Form1()
        {
            InitializeComponent();
            InitializeChromium();
            txtURL.Text = defaultURL;

        }

        void WebView_IsLoadChangedEventHanlder(object sender, EventArgs e)
        {
            //textBoxResponse.Text = "Finished loading document";
        }
       
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            // loading document, it will put a document lock by the current user. The lock will be released after user suspend or close the document 
            if (!isValidationTypeSelected())
            {
                textBoxResponse.Text = "Please provide one service type, select indexing validation or redaction";
                return;
            }
            LoadDocument();
        }

        public void InitializeChromium()
        {
            CefSettings cefSettings = new CefSettings();
            cefSettings.BrowserSubprocessPath = @"~"; // reference to the browsersubprocess file path
            Cef.Initialize(new CefSettings());

            // Create a browser component
            chromeBrowser = new ChromiumWebBrowser("");
            // Add it to the form and fill it to the form window.
            this.panel1.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;
        }


        private void buttonSuspend_Click(object sender, EventArgs e)
        {
            if (!isValidationTypeSelected())
            {
                textBoxResponse.Text = "Please provide one service type, select indexing validation or redaction";
                return;
            }
            buttonLoad.Enabled = true;
            buttonSuspend.Enabled = false;
            buttonClose.Enabled = false;
            var server = parseServerName(txtURL.Text);
            var serviceType = indexingRadioButton.Checked ? "indexing" : "redaction";
            var port = indexingRadioButton.Checked ? "8030" : "8060";

            var appBaseUrl = $"http://{server}:{port}/" + serviceType + "/document";
            // set useCredentials to be true, will pass windows credentials for web api verification
            using (var client = new WebClient { UseDefaultCredentials = true })
            {
                try
                {
                    // make suspend document web api call to release document lock
                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");
                    var response =
                        client.UploadData($"http://{server}:8037/api/validation/{serviceType}/document/suspend/{txtIntellidactId.Text}", "POST", new byte[0]);
                    WebHeaderCollection myWebHeaderCollection = client.ResponseHeaders;
                    var header = myWebHeaderCollection == null ? null : myWebHeaderCollection["x-validation-status"];

                    textBoxResponse.Text = $"x-validation-status: {header}. Document suspended successfully, " + BytesToStringConverted(response);
                    // redirect to suspend page
                    chromeBrowser.Load(appBaseUrl + "/status/" + "Suspended");
                    
                }
                catch (WebException exception)
                {
                    string responseText = null;
                    var responseStream = exception.Response?.GetResponseStream();

                    if (responseStream != null)
                    {
                        using (var reader = new StreamReader(responseStream))
                        {
                            responseText = reader.ReadToEnd();
                        }
                    }
                    WebHeaderCollection myWebHeaderCollection = client.ResponseHeaders;
                    var header = myWebHeaderCollection == null ? null : myWebHeaderCollection["x-validation-error"];
                    textBoxResponse.Text = $"x-validation-error: {header}. Failed to suspend document, " + responseText;
                    // redirect to suspend fail page

                    chromeBrowser.Load(appBaseUrl + "/status/" + "Failed to suspend documment.");
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            if (!isValidationTypeSelected())
            {
                textBoxResponse.Text = "Please provide one service type, select indexing validation or redaction";
                return;
            }
            buttonLoad.Enabled = true;
            buttonSuspend.Enabled = false;
            buttonClose.Enabled = false;
            var server = parseServerName(txtURL.Text);
            var serviceType = indexingRadioButton.Checked ? "indexing" : "redaction";
            var port = indexingRadioButton.Checked ? "8030" : "8060";

            var appBaseUrl = $"http://{server}:{port}/" + serviceType + "/document";
            // set useCredentials to be true, will pass windows credentials for web api verification


            using (var client = new WebClient { UseDefaultCredentials = true })
            {
                try
                {

                    // make close document web api call to release document lock
                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");
                    var response =
                        client.UploadData($"http://{server}:8037/api/validation/{serviceType}/document/close/{txtIntellidactId.Text}", "POST", new byte[0]);
                    WebHeaderCollection myWebHeaderCollection = client.ResponseHeaders;
                    var header = myWebHeaderCollection == null ? null : myWebHeaderCollection["x-validation-status"];

                    textBoxResponse.Text = $"x-validation-status: {header}. Document closed successfully, " + BytesToStringConverted(response);
                    // redirect to close page
                    chromeBrowser.Load(appBaseUrl + "/status/" + "Closed");
                }
                catch (WebException exception)
                {
                    WebHeaderCollection myWebHeaderCollection = client.ResponseHeaders;
                    var header = myWebHeaderCollection == null ? null : myWebHeaderCollection["x-validation-error"];

                    string responseText = null;

                    var responseStream = exception.Response?.GetResponseStream();

                    if (responseStream != null)
                    {
                        using (var reader = new StreamReader(responseStream))
                        {
                            responseText = reader.ReadToEnd();
                        }
                    }

                    textBoxResponse.Text = $"x-validation-error: {header}. Failed to close document, " + responseText;
                    // redirect to close fail page
                    chromeBrowser.Load(appBaseUrl + "/status/" + "Failed to close document.");
                }
            }
        }

        // convert bytes to string
        
        private void txtURL_TextChanged(object sender, EventArgs e)
        {
            buttonLoad.Enabled = true;
        }

        private void txtIntellidactId_TextChanged(object sender, EventArgs e)
        {
            buttonLoad.Enabled = true;

        }       

        private void batchIDTextBox_TextChanged(object sender, EventArgs e)
        {
            buttonLoad.Enabled = true;
        }

        private void retrieveBatchDocsButton_Click(object sender, EventArgs e)
        {

            string result = "";
            List<int> batchIdList = new List<int>();

            string[] stringBatchIds = batchIDTextBox.Text.Split(',');

            foreach (var stringBatchId in stringBatchIds)
            {
                if (string.IsNullOrWhiteSpace(stringBatchId)) continue;
                int batchID = 0;
                bool canConvert = int.TryParse(stringBatchId, out batchID);
                if (!canConvert)
                {
                    textBoxResponse.Text = "The input BatchID array contains one or more invalid integers.";
                    return;
                }

                batchIdList.Add(batchID);
            }


            var batchIdUrl = "";
            foreach (var batchId in batchIdList)
            {
                batchIdUrl += $"batchIds={batchId}";
            }

            using (var client = new WebClient())
            {
                try
                {
                    var server = parseServerName(txtURL.Text);
                    //var serviceType = parseServiceType(txtURL.Text);
                    var serviceType = indexingRadioButton.Checked ? "indexing" : "redaction";

                    // make close document web api call to release document lock
                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");
                    client.Headers.Add("api_key", apiKeyTextBox.Text);
                    var json = client.DownloadString($"http://{server}:8037/api/Batch/Status?" + batchIdUrl);

                    //json = 
                    JArray jsonArray = JArray.Parse(json);
                    dynamic body = JObject.Parse(jsonArray[0].ToString());
                    List<string> intellidactids = new List<string>();
                    if (body["documents"] != null && body["documents"].Type != JTokenType.Null)
                    {
                        var jsonDocuments = JArray.Parse(body["documents"].ToString());
                        foreach (var jsonDocument in jsonDocuments)
                        {
                            var fileName = jsonDocument["intellidactId"]?.ToString();
                            intellidactids.Add(fileName);
                        }
                    }
                    DocumentListBox.DataSource = intellidactids;
                    textBoxResponse.Text = $"Open batch call returned, document listbox populated with {intellidactids.Count} item(s).";

                }
                catch (WebException exception)
                {
                    textBoxResponse.Text = exception.Message;
                    // redirect to close fail page
                }
            }



        }


        private void DocumentListBox_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            ListBox item = sender as ListBox;
            var intellidactId = item.SelectedItem.ToString();
            textBoxResponse.Text = intellidactId;
            txtIntellidactId.Text = intellidactId;
            if (!isValidationTypeSelected())
            {
                textBoxResponse.Text = "Please provide one service type, select indexing validation or redaction";
                return;
            }
            LoadDocument();
        }

        private void LoadDocument()
        {
            if (String.IsNullOrEmpty(txtIntellidactId.Text))
            {
                textBoxResponse.Text = "IntellidactId is not provided. Please double click on document item in the document list to load.";
                return;
            };

            chromeBrowser.ShowDevTools();
            if (!isValidationTypeSelected())
            {
                textBoxResponse.Text = "Please provide one service type, select indexing validation or redaction";
                return;
            }
            // loading document, it will put a document lock by the current user. The lock will be released after user suspend or close the document 

            var server = parseServerName(txtURL.Text);
            var service = indexingRadioButton.Checked ? "indexing" : "redaction";
            var port = indexingRadioButton.Checked ? "8030" : "8060";
            
            var url = $"http://{server}:{port}/" + service + "/document/" + txtIntellidactId.Text;
            chromeBrowser.Load(url);
            buttonLoad.Enabled = false;
            buttonSuspend.Enabled = true;
            buttonClose.Enabled = true;
            textBoxResponse.Text = "Loading document... From Url: " + url;
            //textBoxResponse.Text = webview.IsReady.ToString();
        }
        
        private void indexingRadioButton_Clicked(object sender, EventArgs e)
        {
            if (indexingRadioButton.Checked) redactionRadioButton.Checked = false;
            else redactionRadioButton.Checked = true;
        }

        private void redactionRadioButton_Clicked(object sender, EventArgs e)
        {
            if (redactionRadioButton.Checked) indexingRadioButton.Checked = false;
            else indexingRadioButton.Checked = true;

        }



        private void closeBatchIndexingButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(batchIDTextBox.Text))
            {
                textBoxResponse.Text = "Batch Id is not provided.";
                return;
            };
            buttonLoad.Enabled = true;
            buttonSuspend.Enabled = false;
            buttonClose.Enabled = false;
            var server = parseServerName(txtURL.Text);
            var serviceType = "indexing";
            var port = "8030";

            var appBaseUrl = $"http://{server}:{port}/" + serviceType + "/document";
            // set useCredentials to be true, will pass windows credentials for web api verification


            using (var client = new WebClient { UseDefaultCredentials = true })
            {
                try
                {

                    // make close document web api call to release document lock
                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");
                    var response =
                        client.UploadData($"http://{server}:8037/api/validation/{serviceType}/batch/close/{batchIDTextBox.Text}", "POST", new byte[0]);
                    textBoxResponse.Text = BytesToStringConverted(response);
                }
                catch (WebException exception)
                {

                    string responseText = null;

                    var responseStream = exception.Response?.GetResponseStream();

                    if (responseStream != null)
                    {
                        using (var reader = new StreamReader(responseStream))
                        {
                            responseText = reader.ReadToEnd();
                        }
                    }

                    textBoxResponse.Text = $"Failed to close batch in indexing module, " + responseText;
                }
            }
        }

        private void closeBatchRedactionButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(batchIDTextBox.Text))
            {
                textBoxResponse.Text = "Batch Id is not provided.";
                return;
            };
            buttonLoad.Enabled = true;
            buttonSuspend.Enabled = false;
            buttonClose.Enabled = false;
            var server = parseServerName(txtURL.Text);
            var serviceType = "redaction";
            var port = "8060";

            var appBaseUrl = $"http://{server}:{port}/" + serviceType + "/document";
            // set useCredentials to be true, will pass windows credentials for web api verification

            using (var client = new WebClient { UseDefaultCredentials = true })
            {
                try
                {

                    // make close document web api call to release document lock
                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");
                    var response =
                        client.UploadData($"http://{server}:8037/api/validation/{serviceType}/batch/close/{batchIDTextBox.Text}", "POST", new byte[0]);
                    textBoxResponse.Text = BytesToStringConverted(response);
                }
                catch (WebException exception)
                {

                    string responseText = null;
                    var responseStream = exception.Response?.GetResponseStream();
                    if (responseStream != null)
                    {
                        using (var reader = new StreamReader(responseStream))
                        {
                            responseText = reader.ReadToEnd();
                        }
                    }

                    textBoxResponse.Text = $"Failed to close batch in redaction module, " + responseText;
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }


        #region Utility Method
        private static string BytesToStringConverted(byte[] bytes)
        {
            using (var stream = new MemoryStream(bytes))
            {
                using (var streamReader = new StreamReader(stream))
                {
                    return streamReader.ReadToEnd();


                }
            }
        }

        // parse server name from url
        private string parseServerName(string url)
        {
            try
            {
                if (url.StartsWith("http"))
                {
                    string[] strs = url.Split(':');
                    var str = strs[strs.Length - 2];
                    var strsplit = str.Split('/');
                    return strsplit[strsplit.Length - 1];
                }
                else
                {
                    return url.Split(':')[0];
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // parse service type (indexing or redaction) from url
        private string parseServiceType(string url)
        {
            if (url.Contains("/indexing/"))
            {
                return "indexing";
            }
            if (url.Contains("/redaction/"))
            {
                return "redaction";
            }
            return "";
        }


        private bool isValidationTypeSelected()
        {
            return indexingRadioButton.Checked && !redactionRadioButton.Checked || !indexingRadioButton.Checked && redactionRadioButton.Checked;
        }

        #endregion

    }
}
