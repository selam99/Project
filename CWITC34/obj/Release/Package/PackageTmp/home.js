﻿
<script src="http://code.jquery.com/jquery-1.8.3.js"> </script>
    <script>
        $(document).ready(function () {
            getTheData();
        });

function getTheData() {
    //live server call
    $.ajax({
        url: "eligiblityjson.aspx",
        success: function (result) {
            var j = JSON.parse(result);
            console.log(j);
        }
    });
    //server stub
    console.log(serverStub);

    {
        Records: [
        {
            10418: "Sharilynn "
        },
        {
            10420: "Selam "
        },
        {
            10416: "Shandreeka"
        },
        {
            10417: "Nina "
        },
        {
            10419: "Jasmine "
        }
        ]
    }
}
</script>

   

