<%@ Page Title="Person List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Cloud.Web._Default" %>

    <asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">


    <style>
        .Grid {
            background-color: #fff;
            margin: 5px 0 10px 0;
            border: solid 1px #525252;
            border-collapse: collapse;
            font-family: Calibri;
            color: #474747;
        }

            .Grid td {
                padding: 2px;
                border: solid 1px #c1c1c1;
            }

            .Grid th {
                padding: 4px 2px;
                color: #fff;
                background: #363670 url(Images/grid-header.png) repeat-x top;
                border-left: solid 1px #525252;
                font-size: 0.9em;
            }

            .Grid .alt {
                background: #fcfcfc url(Images/grid-alt.png) repeat-x top;
            }

            .Grid .pgr {
                background: #363670 url(Images/grid-pgr.png) repeat-x top;
            }

                .Grid .pgr table {
                    margin: 3px 0;
                }

                .Grid .pgr td {
                    border-width: 0;
                    padding: 0 6px;
                    border-left: solid 1px #666;
                    font-weight: bold;
                    color: #fff;
                    line-height: 12px;
                }

                .Grid .pgr a {
                    color: Gray;
                    text-decoration: none;
                }

                    .Grid .pgr a:hover {
                        color: #000;
                        text-decoration: none;
                    }
    </style>

    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>

            </hgroup>
        </div>
    </section>
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    
    <asp:GridView ID="gvEmployee" runat="server" AutoGenerateColumns="false" Width="600px"
        AllowPaging="true" PageSize="8"
        CssClass="Grid"
        AlternatingRowStyle-CssClass="alt"
        PagerStyle-CssClass="pgr">
        <Columns>
            <asp:BoundField HeaderText="Employee Name" DataField="FirstName" />
            <asp:BoundField HeaderText="Employee Id" DataField="LastName" />
            <asp:BoundField HeaderText="Listed On" DataField="JoiningDate" />
            
        </Columns>
    </asp:GridView>

</asp:Content>
