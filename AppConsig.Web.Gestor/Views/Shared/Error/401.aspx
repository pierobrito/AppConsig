﻿<% Response.StatusCode = 401%>
<!DOCTYPE html>

<html lang="pt-br" xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title>401 Acesso Proibido</title>
    <meta name="description" content="@ViewBag.Description" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="shortcut icon" href="~/favicon.ico" type="image/x-icon" />

    <!--Basic Styles-->
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="~/Content/font-awesome.min.css" rel="stylesheet" type="text/css" />

    <!--Fonts-->
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:300italic,400italic,600italic,700italic,400,600,700,300"
        rel="stylesheet" type="text/css" />

    <!--Beyond styles-->
    <link href="~/Content/beyond.min.css" rel="stylesheet" type="text/css" />

    <!--Skin Script: Place this script in head to load scripts for skins and rtl support-->
    <link href="~/Content/skins/black.min.css" rel="stylesheet" type="text/css" />

</head>
<body class="body-500">
    <div class="error-header"> </div>
    <div class="container ">
        <section class="error-container text-center">
            <h1>401</h1>
            <div class="error-divider">
                <h2>PARADO!!</h2>
                <p class="description">VOCÊ NÃO POSSUI PERMISSÃO PARA ACESSAR ESSA PÁGINA.</p>
            </div>
            <a href="javascript:history.back(1)" class="return-btn"><i class="fa fa-home"></i>Voltar</a>
        </section>
    </div>
    <!--Basic Scripts-->
    <script src="~/Scripts/jquery-2.1.4.min.js"></script>
    <script src="~/Scripts/bootstrap.min.js"></script>

    <!--Beyond Scripts-->
    <script src="~/Scripts/beyond.min.js"></script>

</body>
</html>
