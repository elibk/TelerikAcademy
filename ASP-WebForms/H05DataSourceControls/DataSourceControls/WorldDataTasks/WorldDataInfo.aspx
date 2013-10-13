<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WorldDataInfo.aspx.cs" Inherits="DataSourceControls.WorldDataTasks.WorldDataInfo" %>
<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
     <asp:EntityDataSource
        ID="EntityDataSourceCountinents"
        ConnectionString="name=TheWorldDBEntities"
        DefaultContainerName="TheWorldDBEntities"
        EntitySetName="Continents"
        EnableFlattening="false"
        runat="server">
    </asp:EntityDataSource>

    <asp:EntityDataSource
        ID="EntityDataSourceAllCountries"
        ConnectionString="name=TheWorldDBEntities"
        DefaultContainerName="TheWorldDBEntities"
        EntitySetName="Countries"
        EnableFlattening="false"
        runat="server">
    </asp:EntityDataSource>

    <asp:EntityDataSource ID="EntityDataSourceCountries" runat="server"
        ConnectionString="name=TheWorldDBEntities"
        DefaultContainerName="TheWorldDBEntities"
        EntitySetName="Countries" Include="Continent, Language"
        EnableFlattening="false" EnableUpdate="true" EnableInsert="true" EnableDelete="true"
        Where="it.ContinentID=@ContinentID">
        <WhereParameters>
            <asp:ControlParameter
                ControlID="ListBoxContinents"
                Name="ContinentID"
                PropertyName="SelectedValue"
                Type="Int32" />
        </WhereParameters>
    </asp:EntityDataSource>

    <asp:EntityDataSource ID="EntityDataSourceTowns" runat="server"
        ConnectionString="name=TheWorldDBEntities"
        DefaultContainerName="TheWorldDBEntities"
        EntitySetName="Towns" Include="Country"
        EnableFlattening="false" EnableUpdate="true" EnableDelete="true" EnableInsert="true"
        Where="it.CountryID=@CountryID">
        <WhereParameters>
            <asp:ControlParameter
                ControlID="GridViewCountries"
                Name="CountryID"
                PropertyName="SelectedValue"
                Type="Int32" />
        </WhereParameters>
    </asp:EntityDataSource>

    <asp:ListBox ID="ListBoxContinents" runat="server"
        DataSourceID="EntityDataSourceCountinents" AutoPostBack="True"
        DataTextField="Name" DataValueField="ContinentID"></asp:ListBox>

    <asp:GridView runat="server"
        ID="GridViewCountries"
        DataKeyNames="CountryID"
        DataSourceID="EntityDataSourceCountries"
        ItemType="DataSourceControls.WorldDataTasks.Country"
        AutoGenerateColumns="False"
        AllowPaging="True" AllowSorting="True">
        <EmptyDataTemplate>
            <p>No countries available.</p>
        </EmptyDataTemplate>
        <Columns>
           <asp:CommandField ShowSelectButton="True" />
           <asp:CommandField ShowEditButton="True" CausesValidation="true" ValidationGroup="GridView_Validator"></asp:CommandField>
           <asp:CommandField ShowDeleteButton="True" />
             <asp:TemplateField 
                SortExpression="Name" 
                HeaderText="Name">
                <EditItemTemplate>
                        <asp:TextBox 
                            ID="TextBoxEditCountryName" 
                            Runat="server" 
                            Text='<%#: Bind("Name") %>'>
                            </asp:TextBox>
                        <asp:RequiredFieldValidator 
                          Runat="server" CssClass="text-error"
                          ErrorMessage="*"
                          ControlToValidate="TextBoxEditCountryName">
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator CssClass="text-error" runat="server"
                            ControlToValidate="TextBoxEditCountryName"
                            ValidationExpression="^[a-zA-Z''-'\s]{1,50}$" Display="None"
                            ErrorMessage="Can only contains lower or up letters and white spaces, but can not starts or ends in white space. It should lenght has between 1 and 50 chars."
                            SetFocusOnError="true" ValidationGroup="GridView_Validator">
                        </asp:RegularExpressionValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label Runat="server" 
                    Text='<%#: Bind("Name") %>' ID="LabelName">
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField 
                SortExpression="Population" 
                HeaderText="Population">
                <EditItemTemplate>
                        <asp:TextBox 
                            ID="TextBoxEditCountryPopulation" 
                            Runat="server" 
                            Text='<%#: Bind("Population") %>'>
                            </asp:TextBox>
                        <asp:RequiredFieldValidator 
                          Runat="server" CssClass="text-error"
                          ErrorMessage="*"
                          ControlToValidate="TextBoxEditCountryPopulation">
                        </asp:RequiredFieldValidator>
                        <asp:CustomValidator CssClass="text-error"
                            EnableClientScript="false" Display="None"
                            ID="CustomValidatorTownPopulation" runat="server"
                            OnServerValidate="CustomValidatorTownPopulation_ServerValidate"
                            ErrorMessage=""
                            ControlToValidate="TextBoxEditCountryPopulation" ValidationGroup="GridView_Validator">
                        </asp:CustomValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label Runat="server" 
                    Text='<%#: Bind("Population") %>' ID="LabelCountryPopulation">
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField 
                SortExpression="Continent" 
                HeaderText="Continent">
                <EditItemTemplate>
                        <asp:DropDownList
                            ID="DDLContinentEdit"
                            DataSourceID="EntityDataSourceCountinents"
                            runat="server" DataTextField='Name'
                            DataValueField="ContinentID"
                            SelectedValue='<%# Bind("ContinentID") %>'
                            AppendDataBoundItems="true">
                            <asp:ListItem Text="--Select country--" Value="-1"></asp:ListItem>
                        </asp:DropDownList>

                        <asp:RequiredFieldValidator 
                            CssClass="text-error" 
                            runat="server" 
                            ControlToValidate="DDLContinentEdit"
                            ErrorMessage="*" ValidationGroup="GridView_Validator">
                        </asp:RequiredFieldValidator>
                        <asp:CustomValidator CssClass="text-error"
                            EnableClientScript="false" Display="None"
                            ID="CustomValidatorContinent" runat="server"
                            OnServerValidate="CustomValidatorInsertCountry_ServerValidate"
                            ErrorMessage="Please select a continent from the list."
                            ControlToValidate="DDLContinentEdit" ValidationGroup="GridView_Validator">
                        </asp:CustomValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label Runat="server"
                    Text='<%#: Item.Continent.Name %>' ID="LabelContinentName">
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
       
    </asp:GridView>

    <asp:ListView ID="ListViewCountries" runat="server" 
            ItemType="DataSourceControls.WorldDataTasks.Country"
             DataSourceID="EntityDataSourceCountries"
            DataKeyNames="CountryID"
            ItemPlaceholderID ="CountriesItemContainer" OnItemInserted="ListViewCountries_ItemInserted">
       <EmptyDataTemplate>
           
             <asp:Button ID="ButtonInsertCountry" Text="New country" runat="server"
                    OnClick="ButtonInsertCountry_Click" />  
       </EmptyDataTemplate>
            <LayoutTemplate>
                <span runat="server" id="CountriesItemContainer" /> 
                <asp:Button ID="ButtonInsertCountry" Text="New country" runat="server"
                    OnClick="ButtonInsertCountry_Click" />      
            </LayoutTemplate>
             <ItemTemplate>
             </ItemTemplate>
            <InsertItemTemplate>
            <div class="insertCountryContainer">
                <ul>
                    <li>(auto generated) </li>
                    <li>
                        <asp:Label 
                            runat="server" 
                            AssociatedControlID="TextBoxCountryNameInsert" 
                            Text="Country Name"></asp:Label>
                        <asp:TextBox 
                            ID="TextBoxCountryNameInsert" 
                            runat="server" 
                            Text='<%#: BindItem.Name %>' />
                        <asp:RequiredFieldValidator  ValidationGroup="InsertCountry"
                            CssClass="text-error" 
                            runat="server" 
                            ControlToValidate="TextBoxCountryNameInsert" 
                            ErrorMessage="*">
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ValidationGroup="InsertCountry"
                            CssClass="text-error" runat="server"
                            ControlToValidate="TextBoxCountryNameInsert"
                            ValidationExpression="^[a-zA-Z''-'\s]{1,50}$"
                            ErrorMessage="Can only contains lower or up letters and white spaces, but can not starts or ends in white space. It should lenght has between 1 and 50 chars."
                            SetFocusOnError="true">
                        </asp:RegularExpressionValidator>
                    </li>
                    <li>
                        <asp:Label 
                            runat="server" 
                            AssociatedControlID="TextBoxPopulationCountryInsert" 
                            Text="Population"></asp:Label>
                        <asp:TextBox 
                            ID="TextBoxPopulationCountryInsert" 
                            runat="server" 
                            Text='<%# BindItem.Population %>' />
                        <asp:RequiredFieldValidator ValidationGroup="InsertCountry"
                            CssClass="text-error"
                            runat="server" 
                            ControlToValidate="TextBoxPopulationCountryInsert" 
                            ErrorMessage="*">
                        </asp:RequiredFieldValidator>
                        <asp:CustomValidator ValidationGroup="InsertCountry"
                            CssClass="text-error"
                            EnableClientScript="false"
                            ID="CustomValidatorTownPopulationInsert" 
                            runat="server"
                            OnServerValidate="CustomValidatorTownPopulation_ServerValidate"
                            ErrorMessage=""
                            ControlToValidate="TextBoxPopulationCountryInsert">
                        </asp:CustomValidator>
                    </li>
                    <li>
                        <asp:Label 
                            runat="server" 
                            AssociatedControlID="DDLContinentNameFromCountryInsert" 
                            Text="Country"></asp:Label>
                        <asp:DropDownList
                            ID="DDLContinentNameFromCountryInsert"
                            DataSourceID="EntityDataSourceCountinents"
                            runat="server" DataTextField='Name'
                            DataValueField="ContinentID"
                            SelectedValue="<%# BindItem.ContinentID %>"
                            AppendDataBoundItems="true">
                            <asp:ListItem Text="--Select continent--" Value="-1"></asp:ListItem>
                        </asp:DropDownList>

                        <asp:RequiredFieldValidator ValidationGroup="InsertCountry"
                            CssClass="text-error" 
                            runat="server" 
                            ControlToValidate="DDLContinentNameFromCountryInsert" 
                            ErrorMessage="*">
                        </asp:RequiredFieldValidator>
                        <asp:CustomValidator CssClass="text-error" ValidationGroup="InsertCountry"
                            EnableClientScript="false"
                            ID="CustomValidatorInsertContinent" runat="server"
                            OnServerValidate="CustomValidatorInsertCountry_ServerValidate"
                            ErrorMessage="Please select a continent from the list."
                            ControlToValidate="DDLContinentNameFromCountryInsert">
                        </asp:CustomValidator>
                    </li>
                    <li>
                        <asp:Button ID="ButtonInsertCountry" ValidationGroup="InsertCountry" runat="server" CommandName="Insert" Text="Insert" />
                    </li>
                    <li>
                        <asp:Button ID="ButtonClearCountry" runat="server" CommandName="Cancel" Text="Clear" />
                    </li>
                </ul>
            </div>
        </InsertItemTemplate>
        </asp:ListView>

    <asp:ValidationSummary 
        ID="ValidationSummary_GridView" runat="server" CssClass="text-error"
        DisplayMode="SingleParagraph" ValidationGroup="GridView_Validator" ShowValidationErrors="true" /> 
    
    <asp:ListView ID="TownsListView" runat="server"
        ItemType="DataSourceControls.WorldDataTasks.Town"
        DataSourceID="EntityDataSourceTowns"
        DataKeyNames="TownID" OnItemInserted="ListViewTowns_ItemInserted">
        <EmptyDataTemplate>
            <p>No towns available.</p>
            <asp:Button ID="ButtonInsertTown" Text="New town" runat="server"
                OnClick="ButtonInsertTown_Click" />
        </EmptyDataTemplate>
        <LayoutTemplate>
            <span runat="server" id="itemPlaceholder" />
            <div class="pagerLine">
                <asp:Button ID="ButtonInsertTown" Text="New town" runat="server"
                    OnClick="ButtonInsertTown_Click" />
                
                    <asp:DataPager ID="DataPagerCustomers" runat="server" PageSize="4">
                        <Fields>
                            <asp:NextPreviousPagerField ShowFirstPageButton="True"
                                ShowNextPageButton="False" ShowPreviousPageButton="False" />
                            <asp:NumericPagerField />
                            <asp:NextPreviousPagerField ShowLastPageButton="True"
                                ShowNextPageButton="False" ShowPreviousPageButton="False" />
                        </Fields>
                    </asp:DataPager>
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <ul>
                <li>Name: <%#: Item.Name %> </li>
                <li>Population: <%#: string.Format("{0: #,#}", Item.Population) %></li>
                <li>Country:  <%#: Item.Country.Name %></li>
                <li>
                    <asp:Button ID="ButtonEdit" runat="server" CommandName="Edit" Text="Edit" /></li>
                <li>
                    <asp:Button ID="ButtonDelete" runat="server" CommandName="Delete" Text="Delete" />
                </li>
            </ul>
        </ItemTemplate>
        <EditItemTemplate>
            <div class="editItem">
                <ul>
                    <li>Town ID: <%#: Item.TownID %> </li>
                    <li>
                        <asp:Label runat="server" AssociatedControlID="TextBoxTownName" Text="Town Name"></asp:Label>
                        <asp:TextBox ID="TextBoxTownName" runat="server" Text='<%#: BindItem.Name %>' />
                        <asp:RequiredFieldValidator CssClass="text-error" runat="server" ControlToValidate="TextBoxTownName" ErrorMessage="*">
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator CssClass="text-error" runat="server"
                            ControlToValidate="TextBoxTownName"
                            ValidationExpression="^[a-zA-Z''-'\s]{1,50}$"
                            ErrorMessage="Can only contains lower or up letters and white spaces, but can not starts or ends in white space. It should lenght has between 1 and 50 chars."
                            SetFocusOnError="true">
                        </asp:RegularExpressionValidator>
                    </li>
                    <li>
                        <asp:Label runat="server" AssociatedControlID="TextBoxPopulation" Text="Population"></asp:Label>
                        <asp:TextBox ID="TextBoxPopulation" runat="server" Text='<%# BindItem.Population %>' />
                        <asp:RequiredFieldValidator CssClass="text-error" runat="server" ControlToValidate="TextBoxPopulation" ErrorMessage="*">
                        </asp:RequiredFieldValidator>
                        <asp:CustomValidator CssClass="text-error"
                            EnableClientScript="false"
                            ID="CustomValidatorTownPopulation" runat="server"
                            OnServerValidate="CustomValidatorTownPopulation_ServerValidate"
                            ErrorMessage=""
                            ControlToValidate="TextBoxPopulation">
                        </asp:CustomValidator>
                    </li>
                     <li>
                        <asp:Label runat="server" AssociatedControlID="DDLCountryInsert" Text="Country"></asp:Label>
                        <asp:DropDownList
                            ID="DDLCountryInsert"
                            DataSourceID="EntityDataSourceAllCountries"
                            runat="server" DataTextField='Name'
                            DataValueField="CountryID"
                            SelectedValue="<%# BindItem.CountryID %>"
                            AppendDataBoundItems="true">
                            <asp:ListItem Text="--Select country--" Value="-1"></asp:ListItem>
                        </asp:DropDownList>

                        <asp:RequiredFieldValidator CssClass="text-error" runat="server" ControlToValidate="DDLCountryInsert" ErrorMessage="*">
                        </asp:RequiredFieldValidator>
                        <asp:CustomValidator CssClass="text-error"
                            EnableClientScript="false"
                            ID="CustomValidatorInsertCountry" runat="server"
                            OnServerValidate="CustomValidatorInsertCountry_ServerValidate"
                            ErrorMessage="Please select a country from the list."
                            ControlToValidate="DDLCountryInsert">
                        </asp:CustomValidator>
                    </li>
                    <li>
                        <asp:Button ID="ButtonUpdate" runat="server" CommandName="Update" Text="Update" />
                    </li>
                    <li>
                        <asp:Button ID="ButtonCancel" runat="server" CommandName="Cancel" Text="Cancel" />
                    </li>
                </ul>
            </div>
        </EditItemTemplate>
        <InsertItemTemplate>
            <div class="insertItem">
                <ul>
                    <li>(auto generated) </li>
                    <li>
                        <asp:Label 
                            runat="server" 
                            AssociatedControlID="TextBoxTownNameInsert" 
                            Text="Town Name"></asp:Label>
                        <asp:TextBox 
                            ID="TextBoxTownNameInsert" 
                            runat="server" 
                            Text='<%#: BindItem.Name %>' />
                        <asp:RequiredFieldValidator 
                            CssClass="text-error" 
                            runat="server"
                             ControlToValidate="TextBoxTownNameInsert" 
                            ErrorMessage="*" ValidationGroup="InsertTown">
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator 
                            CssClass="text-error" runat="server"
                            ControlToValidate="TextBoxTownNameInsert"
                            ValidationExpression="^[a-zA-Z''-'\s]{1,50}$"
                            ErrorMessage="Can only contains lower or up letters and white spaces, but can not starts or ends in white space. It should lenght has between 1 and 50 chars."
                            SetFocusOnError="true" ValidationGroup="InsertTown">
                        </asp:RegularExpressionValidator>
                    </li>
                    <li>
                        <asp:Label 
                            runat="server" 
                            AssociatedControlID="TextBoxPopulationInsert" 
                            Text="Population"></asp:Label>
                        <asp:TextBox 
                            ID="TextBoxPopulationInsert" 
                            runat="server" 
                            Text='<%# BindItem.Population %>' />
                        <asp:RequiredFieldValidator 
                            CssClass="text-error" runat="server" 
                            ControlToValidate="TextBoxPopulationInsert"
                             ErrorMessage="*" ValidationGroup="InsertTown">
                        </asp:RequiredFieldValidator>
                        <asp:CustomValidator CssClass="text-error"
                            EnableClientScript="false"
                            ID="CustomValidatorTownPopulationInsert" runat="server"
                            OnServerValidate="CustomValidatorTownPopulation_ServerValidate"
                            ErrorMessage=""
                            ControlToValidate="TextBoxPopulationInsert" ValidationGroup="InsertTown">
                        </asp:CustomValidator>
                    </li>
                    <li>
                        <asp:Label runat="server" AssociatedControlID="DDLCountryInsert" Text="Country"></asp:Label>
                        <asp:DropDownList
                            ID="DDLCountryInsert"
                            DataSourceID="EntityDataSourceAllCountries"
                            runat="server" DataTextField='Name'
                            DataValueField="CountryID"
                            SelectedValue="<%# BindItem.CountryID %>"
                            AppendDataBoundItems="true">
                            <asp:ListItem Text="--Select country--" Value="-1"></asp:ListItem>
                        </asp:DropDownList>

                        <asp:RequiredFieldValidator 
                            CssClass="text-error" ValidationGroup="InsertTown"
                            runat="server" ControlToValidate="DDLCountryInsert" ErrorMessage="*">
                        </asp:RequiredFieldValidator>
                        <asp:CustomValidator CssClass="text-error"
                            ValidationGroup="InsertTown"
                            EnableClientScript="false"
                            ID="CustomValidatorInsertCountry" runat="server"
                            OnServerValidate="CustomValidatorInsertCountry_ServerValidate"
                            ErrorMessage="Please select a country from the list."
                            ControlToValidate="DDLCountryInsert">
                        </asp:CustomValidator>
                    </li>
                    <li>
                        <asp:Button ID="ButtonInsertTown" ValidationGroup="InsertTown" runat="server" CommandName="Insert" Text="Insert" />
                    </li>
                    <li>
                        <asp:Button ID="ButtonCancelTown"  runat="server" CommandName="Cancel" Text="Clear" />
                    </li>
                </ul>
            </div>
        </InsertItemTemplate>
    </asp:ListView>

  
</asp:Content>
