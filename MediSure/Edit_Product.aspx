<%@ Page Title="Edit Products" Language="C#" MasterPageFile="~/MediSureTemplate.Master" AutoEventWireup="true" CodeBehind="Edit_Product.aspx.cs" Inherits="MediSure.Edit_Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Edit Products</h2>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
        DataKeyNames="Product_ID"
        OnRowEditing="GridView1_RowEditing"
        OnRowUpdating="GridView1_RowUpdating"
        OnRowCancelingEdit="GridView1_RowCancelingEdit"
        CssClass="table table-bordered">

        <Columns>
            <asp:BoundField DataField="Product_ID" HeaderText="ID" ReadOnly="True" />
            <asp:BoundField DataField="Product_Name" HeaderText="Name" ReadOnly="True" />
            <asp:TemplateField HeaderText="Price">
                <ItemTemplate>
                    <%# Eval("Product_Price") %>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox_Price" runat="server" Text='<%# Eval("Product_Price") %>' />
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Description">
                <ItemTemplate>
                    <%# Eval("Product_Description") %>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox_Description" runat="server" Text='<%# Eval("Product_Description") %>' />
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Image">
                <ItemTemplate>
                    <asp:Image ID="img" runat="server" ImageUrl='<%# Eval("Product_Image") %>' Width="60" Height="40" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:FileUpload ID="FileUpload_newimg" runat="server" />
                    <asp:Label ID="lblImagePath" runat="server" Text='<%# Eval("Product_Image") %>' Visible="false" />
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Stock">
                <ItemTemplate>
                    <%# Eval("Stock") %>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox_Stock" runat="server" Text='<%# Eval("Stock") %>' />
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                    <%# Eval("Product_Status") %>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="DropDownList_status" runat="server">
                        <asp:ListItem Text="Active" />
                        <asp:ListItem Text="Inactive" />
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:CommandField ShowEditButton="True" />
        </Columns>
    </asp:GridView>
</asp:Content>
