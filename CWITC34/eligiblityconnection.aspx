<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="eligiblityconnection.aspx.cs" Inherits="CWITC34.eligiblityconnection" %>

<!DOCTYPE html>
<html>
<head>
    <title> Home Page </title>
    </head>
    
    <body>
    
    <script src="http://code.jquery.com/jquery-1.8.3.js"> </script>
    <script>
   var connect= $(document).ready(function () {
            $.ajax({
               url: "eligiblityjson.aspx",
               success: function (result) {
   	var j = JSON.parse(result);
              	$("#elig").append(j);
                    	console.log(j);
                		$.each(j, function(i, item) {
                    			$("#elig").append('<div>data: '+item+ '</div>');
                		});
                }
            });
        });
    </script>
   
    <button type="button" id="elig" class="btn btn-primary btn-block">Search Eligiblity</button><br/>
                
     </body>
</html>
