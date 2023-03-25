<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserDetails.aspx.cs" Inherits="loginwebapi2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>UserDetails</title>
     <script src="Scripts/jquery-3.3.1.js"></script>
    <script>    

        $(document).ready(function(){


            $('#btnGetByIdData').click(function () {

                $.ajax({

                    type: "Get",
                    url: "http://localhost:58814/Api/Values/GetUSer?UserID=" + $("#txtUserId").val(),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {

                        var str = "";

                        str = "<tr>" + "<td>" + response.FirstName + "</td>" + "<td>" + response.LastName + "</td>" + "<td>" + response.UserName + "</td>" + "<td>" + response.Email + "</td>" + "<td>" + response.Gender + "</td>" + "</tr>";

                        $("#tblShowData").find("tr:gt(0)").remove();

                        $("#tblShowData").append(str);

                        str = "";
                    },
                    failure: function (response) {
                        alert(response.d);
                    }
                });  // endo of ajax

            });  //end of click

        });  // end of docu

    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>

            <br />
            <br />



            <input type="text" id="txtUserId" />

            <input id="btnGetByIdData" type="button" value="Get Data By Id" />


            <br />
            <br />
            <br />

            <table id="tblShowData" border="1">
                <thead>
                    <td>FirstName </td>
                    <td>LastName </td>
                    <td>UserName </td>
                    <td>Email </td>

                    <td>Gender </td>

                </thead>

                <tbody>
                </tbody>

            </table>


        </div>
    </form>
    <p>
        &nbsp;
    </p>
</body>
</html>
