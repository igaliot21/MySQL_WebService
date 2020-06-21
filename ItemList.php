<?php
    // http://192.168.1.20/webservice/MovieList.php?user=test&password=test&reg_inicio=10&max_reg=10
    // usuario/password
    $user = trim($_GET['user']);
    $pass = trim($_GET['password']);
    // rango de registros a leer, por defecto todas
    $reg_post = trim($_GET['reg_inicio']);
    if (!is_numeric($reg_post)){$reg_lectura = 0;}
    else{$reg_lectura = $reg_post;}
    //
    $reg_max = trim($_GET['max_reg']);
    if (!is_numeric($reg_max)){$max_reg = 20000;}
    else{$max_reg = $reg_max;}    
    //
    //
    $con = mysql_connect("localhost",$user,$pass);
    if (!$con){
        die('Error de db ' . mysql_error());
    }
    //
    mysql_select_db("TestDB",$con);
    $recordset=mysql_query("SELECT * FROM TestTable LIMIT " . $reg_lectura . ", " . $max_reg);    
    $datos=array();
    while($row = mysql_fetch_array($recordset)){
        array_push($datos,array(
            'Id'=>$row['Id'],
            'Name'=>$row['Name'],
            'Category'=>$row['Category'],
            'Price'=>$row['Price']
        ));
    }

    echo utf8_encode(json_encode($datos, JSON_NUMERIC_CHECK));
?>