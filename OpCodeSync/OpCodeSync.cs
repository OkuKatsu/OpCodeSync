using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Advanced_Combat_Tracker;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Linq;
using Machina.FFXIV.Headers;
using OpCodeSync;
using Label = System.Windows.Forms.Label;

[assembly: AssemblyTitle("OpCode Sync")]
[assembly: AssemblyDescription("A ACT plugin that update OpCodes for FFXIV_ACT_Plugin")]
[assembly: AssemblyCompany("Oku Katsu")]
[assembly: AssemblyVersion("1.0.0.2")]

namespace ACT_Plugin
{
    public class OpCodeSync : UserControl, IActPluginV1
    {
        #region Designer Created Code (Avoid editing)
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OpCodeSyncGroupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.OpCodeListBox = new System.Windows.Forms.ListBox();
            this.ExportCurrentOpCodesButton = new System.Windows.Forms.Button();
            this.ClearLogButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.LoglistBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LoadLocalOpCodes = new System.Windows.Forms.Button();
            this.LoadOnlineOpCodes = new System.Windows.Forms.Button();
            this.InjectOpCodes = new System.Windows.Forms.Button();
            this.OpCodeSyncGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpCodeSyncGroupBox1
            // 
            this.OpCodeSyncGroupBox1.Controls.Add(this.label3);
            this.OpCodeSyncGroupBox1.Controls.Add(this.label2);
            this.OpCodeSyncGroupBox1.Controls.Add(this.OpCodeListBox);
            this.OpCodeSyncGroupBox1.Controls.Add(this.ExportCurrentOpCodesButton);
            this.OpCodeSyncGroupBox1.Controls.Add(this.ClearLogButton);
            this.OpCodeSyncGroupBox1.Controls.Add(this.comboBox1);
            this.OpCodeSyncGroupBox1.Controls.Add(this.LoglistBox1);
            this.OpCodeSyncGroupBox1.Controls.Add(this.label1);
            this.OpCodeSyncGroupBox1.Controls.Add(this.LoadLocalOpCodes);
            this.OpCodeSyncGroupBox1.Controls.Add(this.LoadOnlineOpCodes);
            this.OpCodeSyncGroupBox1.Controls.Add(this.InjectOpCodes);
            this.OpCodeSyncGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.OpCodeSyncGroupBox1.Name = "OpCodeSyncGroupBox1";
            this.OpCodeSyncGroupBox1.Size = new System.Drawing.Size(807, 471);
            this.OpCodeSyncGroupBox1.TabIndex = 0;
            this.OpCodeSyncGroupBox1.TabStop = false;
            this.OpCodeSyncGroupBox1.Text = "OpCode Sync";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(204, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "日志";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "当前插件 OpCodes";
            // 
            // OpCodeListBox
            // 
            this.OpCodeListBox.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpCodeListBox.FormattingEnabled = true;
            this.OpCodeListBox.ItemHeight = 15;
            this.OpCodeListBox.Location = new System.Drawing.Point(6, 65);
            this.OpCodeListBox.Name = "OpCodeListBox";
            this.OpCodeListBox.Size = new System.Drawing.Size(192, 364);
            this.OpCodeListBox.TabIndex = 9;
            this.OpCodeListBox.Tag = "";
            // 
            // ExportCurrentOpCodesButton
            // 
            this.ExportCurrentOpCodesButton.Location = new System.Drawing.Point(557, 435);
            this.ExportCurrentOpCodesButton.Name = "ExportCurrentOpCodesButton";
            this.ExportCurrentOpCodesButton.Size = new System.Drawing.Size(119, 23);
            this.ExportCurrentOpCodesButton.TabIndex = 8;
            this.ExportCurrentOpCodesButton.Text = "导出当前 OpCodes";
            this.ExportCurrentOpCodesButton.UseVisualStyleBackColor = true;
            this.ExportCurrentOpCodesButton.Click += new System.EventHandler(this.ExportCurrentOpCodesButton_Click);
            // 
            // ClearLogButton
            // 
            this.ClearLogButton.Location = new System.Drawing.Point(682, 435);
            this.ClearLogButton.Name = "ClearLogButton";
            this.ClearLogButton.Size = new System.Drawing.Size(119, 23);
            this.ClearLogButton.TabIndex = 6;
            this.ClearLogButton.Text = "清空日志";
            this.ClearLogButton.UseVisualStyleBackColor = true;
            this.ClearLogButton.Click += new System.EventHandler(this.ClearLogButton_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Global 国际服",
            "CN 国服",
            "KR 韩服"});
            this.comboBox1.Location = new System.Drawing.Point(77, 22);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 5;
            // 
            // LoglistBox1
            // 
            this.LoglistBox1.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoglistBox1.FormattingEnabled = true;
            this.LoglistBox1.ItemHeight = 15;
            this.LoglistBox1.Location = new System.Drawing.Point(204, 65);
            this.LoglistBox1.Name = "LoglistBox1";
            this.LoglistBox1.Size = new System.Drawing.Size(597, 364);
            this.LoglistBox1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "客户端版本";
            // 
            // LoadLocalOpCodes
            // 
            this.LoadLocalOpCodes.Location = new System.Drawing.Point(557, 19);
            this.LoadLocalOpCodes.Name = "LoadLocalOpCodes";
            this.LoadLocalOpCodes.Size = new System.Drawing.Size(119, 23);
            this.LoadLocalOpCodes.TabIndex = 2;
            this.LoadLocalOpCodes.Text = "加载本地 OpCodes";
            this.LoadLocalOpCodes.UseVisualStyleBackColor = true;
            this.LoadLocalOpCodes.Click += new System.EventHandler(this.LoadLocalOpCodes_Click);
            // 
            // LoadOnlineOpCodes
            // 
            this.LoadOnlineOpCodes.Location = new System.Drawing.Point(432, 19);
            this.LoadOnlineOpCodes.Name = "LoadOnlineOpCodes";
            this.LoadOnlineOpCodes.Size = new System.Drawing.Size(119, 23);
            this.LoadOnlineOpCodes.TabIndex = 1;
            this.LoadOnlineOpCodes.Text = "加载云端 OpCodes";
            this.LoadOnlineOpCodes.UseVisualStyleBackColor = true;
            this.LoadOnlineOpCodes.Click += new System.EventHandler(this.LoadOnlineOpCodes_Click);
            // 
            // InjectOpCodes
            // 
            this.InjectOpCodes.Location = new System.Drawing.Point(682, 19);
            this.InjectOpCodes.Name = "InjectOpCodes";
            this.InjectOpCodes.Size = new System.Drawing.Size(119, 23);
            this.InjectOpCodes.TabIndex = 0;
            this.InjectOpCodes.Text = "注入 OpCodes";
            this.InjectOpCodes.UseVisualStyleBackColor = true;
            this.InjectOpCodes.Click += new System.EventHandler(this.InjectOpCodes_Click);
            // 
            // OpCodeSync
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.OpCodeSyncGroupBox1);
            this.Name = "OpCodeSync";
            this.Size = new System.Drawing.Size(813, 477);
            this.OpCodeSyncGroupBox1.ResumeLayout(false);
            this.OpCodeSyncGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        #endregion
        public OpCodeSync()
        {
            InitializeComponent();
        }

        Label lblStatus;    // The status label that appears in ACT's Plugin tab
        string settingsFile = Path.Combine(ActGlobals.oFormActMain.AppDataFolder.FullName, "Config\\OpCodeSync.config.xml");
        private GroupBox OpCodeSyncGroupBox1;
        private ComboBox comboBox1;
        private ListBox LoglistBox1;
        private Label label1;
        private Button LoadLocalOpCodes;
        private Button LoadOnlineOpCodes;
        private Button InjectOpCodes;
        private Button ClearLogButton;
        private Button ExportCurrentOpCodesButton;
        private ListBox OpCodeListBox;
        private Label label3;
        private Label label2;
        SettingsSerializer xmlSettings;

        public Dictionary<string, ushort> CurrentOpcodes { get; set; }

        #region IActPluginV1 Members
        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            lblStatus = pluginStatusText;   // Hand the status label's reference to our local var
            pluginScreenSpace.Controls.Add(this);   // Add this UserControl to the tab ACT provides
            pluginScreenSpace.Text = "OpCode Sync";
            this.Dock = DockStyle.Fill; // Expand the UserControl to fill the tab's client space
            xmlSettings = new SettingsSerializer(this); // Create a new settings serializer and pass it this instance
            LoadSettings();

            // Create some sort of parsing event handler.  After the "+=" hit TAB twice and the code will be generated for you.
            ActGlobals.oFormActMain.AfterCombatAction += new CombatActionDelegate(oFormActMain_AfterCombatAction);

            comboBox1.SelectedIndex = 0;

            GetCurrentOpcodesMachina();

            lblStatus.Text = "Plugin Started";
        }
        public void DeInitPlugin()
        {
            // Unsubscribe from any events you listen to when exiting!
            ActGlobals.oFormActMain.AfterCombatAction -= oFormActMain_AfterCombatAction;

            SaveSettings();
            lblStatus.Text = "Plugin Exited";
        }
        #endregion

        void oFormActMain_AfterCombatAction(bool isImport, CombatActionEventArgs actionInfo)
        {
            throw new NotImplementedException();
        }

        void LoadSettings()
        {
            if (File.Exists(settingsFile))
            {
                FileStream fs = new FileStream(settingsFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                XmlTextReader xReader = new XmlTextReader(fs);

                try
                {
                    while (xReader.Read())
                    {
                        if (xReader.NodeType == XmlNodeType.Element)
                        {
                            if (xReader.LocalName == "SettingsSerializer")
                            {
                                xmlSettings.ImportFromXml(xReader);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "Error loading settings: " + ex.Message;
                }
                xReader.Close();
            }
        }
        void SaveSettings()
        {
            FileStream fs = new FileStream(settingsFile, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            XmlTextWriter xWriter = new XmlTextWriter(fs, Encoding.UTF8);
            xWriter.Formatting = Formatting.Indented;
            xWriter.Indentation = 1;
            xWriter.IndentChar = '\t';
            xWriter.WriteStartDocument(true);
            xWriter.WriteStartElement("Config");    // <Config>
            xWriter.WriteStartElement("SettingsSerializer");    // <Config><SettingsSerializer>
            xmlSettings.ExportToXml(xWriter);   // Fill the SettingsSerializer XML
            xWriter.WriteEndElement();  // </SettingsSerializer>
            xWriter.WriteEndElement();  // </Config>
            xWriter.WriteEndDocument(); // Tie up loose ends (shouldn't be any)
            xWriter.Flush();    // Flush the file buffer to disk
            xWriter.Close();
        }

        public void UILog(string message)
        {
            RunOnACTUIThread(delegate
            {
                LoglistBox1.Items.Add(message);
                LoglistBox1.SelectedIndex = LoglistBox1.Items.Count - 1;
                LoglistBox1.SelectedItem = message;
                LoglistBox1.TopIndex = LoglistBox1.Items.Count - 1;
            });
        }

        public void OpCodesInfo(string message)
        {
            RunOnACTUIThread(delegate
            {
                OpCodeListBox.Items.Add(message);
                OpCodeListBox.SelectedIndex = OpCodeListBox.Items.Count - 1;
                OpCodeListBox.SelectedItem = message;
                OpCodeListBox.TopIndex = OpCodeListBox.Items.Count - 1;
            });
        }

        internal static void RunOnACTUIThread(Action code)
        {
            if (ActGlobals.oFormActMain.InvokeRequired && !ActGlobals.oFormActMain.IsDisposed && !ActGlobals.oFormActMain.Disposing)
            {
                ActGlobals.oFormActMain.Invoke(code);
            }
            else
            {
                code();
            }
        }

        private void ClearLogButton_Click(object sender, EventArgs e)
        {
            LoglistBox1.Items.Clear();
        }

        private void LoadLocalOpCodes_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.Title = "请选择文件";
            dialog.Filter = "所有文件(*.txt)|*.txt";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                GetOpcodesFromTxt(dialog.FileName);
            }
        }

        private void GetOpcodesFromString(string opCodeString)
        {
            string[][] data = opCodeString.Split(new string[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries)).ToArray();
            var dict = data.ToDictionary(
                x => x[0].Trim(),
                x => Convert.ToUInt16(x[1].Trim(), 16));
            CurrentOpcodes = dict;
            UILog($"已载入{CurrentOpcodes.Count}个OpCode");
            foreach (KeyValuePair<string, ushort> kvp in CurrentOpcodes)
            {
                UILog($"{kvp.Key}|{kvp.Value:X4}");
            }
        }

        private void GetOpcodesFromTxt(string txtPath)
        {
            if (!File.Exists(txtPath))
            {
                UILog($"{txtPath} 不存在！");
                return;
            }
            using (StreamReader sr = new StreamReader(txtPath))
            {
                GetOpcodesFromString(sr.ReadToEnd());
            }
        }

        private Dictionary<string, ushort> GetCurrentOpcodes()
        {
            UILog("获取当前解析插件中的 OpCode...");

            Dictionary<string, ushort> opcodeDictionary = new Dictionary<string, ushort>();
            opcodeDictionary = GetCurrentOpcodesMachina();

            foreach (var opcode in opcodeDictionary)
            {
                UILog($"{opcode.Key}|{opcode.Value:X4}");
            }

            return opcodeDictionary;
        }

        private Dictionary<string, ushort> GetCurrentOpcodesMachina()
        {
            FieldInfo[] opcodes = typeof(Server_MessageType).GetFields();
            Type type = typeof(Server_MessageType);
            object obj1 = type.Assembly.CreateInstance(type.FullName);

            Dictionary<string, ushort> opcodeDictionary = new Dictionary<string, ushort>();

            OpCodeListBox.Items.Clear();
            OpCodeListBox.Items.Add("当前 OpCodes");
            foreach (var opcode in opcodes)
            {
                ushort opcodeValue = (ushort)(Server_MessageType)opcode.GetValue(obj1);
                opcodeDictionary.Add(opcode.Name, opcodeValue);
                OpCodesInfo($"{opcode.Name}|{(opcodeValue):X4}");
            }

            return opcodeDictionary;
        }

        private void GetCurrentOpCode_Click(object sender, EventArgs e)
        {
            GetCurrentOpcodes();
        }

        private void SaveCurrentOpCodesToFile(string txtPath, Dictionary<string, ushort> opcodes)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(txtPath))
                {
                    foreach (var opcode in opcodes)
                    {
                        writer.WriteLine($"{opcode.Key}|{opcode.Value:X4}");
                    }
                }
                UILog($"OpCodes 已成功保存到 {txtPath}");
            }
            catch (Exception ex)
            {
                UILog($"保存 OpCodes 时发生错误: {ex.Message}");
            }
        }

        private void ExportCurrentOpCodesButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "文本文件 (*.txt)|*.txt|所有文件 (*.*)|*.*";
            dialog.Title = "请选择保存文件的位置";
            dialog.DefaultExt = "txt";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SaveCurrentOpCodesToFile(dialog.FileName, GetCurrentOpcodesMachina());
            }
        }

        private async void LoadOnlineOpcodeJson()
        {
            UILog("正在加载云端 OpCodes 列表...");
            OnlineOpCodes onlineOpCodes = new OnlineOpCodes();
            List<OpCode> opCodes = await onlineOpCodes.GetOnlineOpcodeAsync();
            foreach (OpCode op in opCodes)
            {
                UILog($"时间: {op.Time}, 服务器: {op.Server}");
            }

            UILog($"已载入{opCodes.Count}个 OpCode");

            if (comboBox1.SelectedIndex == 0)
            {
                UILog("解析 Global 国际服 OpCode");
                foreach (OpCode op in opCodes)
                {
                    if (op.Server == "Global")
                    {
                        GetOpcodesFromString(op.Opcode);
                    }
                }
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                UILog("解析 CN 国服 OpCode");
                foreach (OpCode op in opCodes)
                {
                    if (op.Server == "CN")
                    {
                        GetOpcodesFromString(op.Opcode);
                    }
                }
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                UILog("解析 KR 韩服 OpCode");
                foreach (OpCode op in opCodes)
                {
                    if (op.Server == "KR")
                    {
                        GetOpcodesFromString(op.Opcode);
                    }
                }
            }
        }

        private void LoadOnlineOpCodes_Click(object sender, EventArgs e)
        {
            LoadOnlineOpcodeJson();
        }

        public void SetOpcodes()
        {
            UILog("注入 OpCode...");
            FieldInfo[] opcodes = typeof(Server_MessageType).GetFields();
            Type type = typeof(Server_MessageType);
            object obj1 = type.Assembly.CreateInstance(type.FullName);
            foreach (var opcode in opcodes)
            {
                ushort newOpCode = 0;
                if (CurrentOpcodes.TryGetValue(opcode.Name, out newOpCode))
                    opcode.SetValue(obj1, (Server_MessageType)newOpCode);
                else
                    UILog($"没找到{opcode.Name}");
            }
            UILog("注入 OpCode 成功，请重新加载 FFXIV_ACT_Plugin");
        }

        private void InjectOpCodes_Click(object sender, EventArgs e)
        {
            SetOpcodes();
            GetCurrentOpcodesMachina();
        }
    }
}
