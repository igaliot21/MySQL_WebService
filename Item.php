<?php
    // http://192.168.1.20/webservice/Movie.php?user=test&password=test&id=11 
    // usuario/password
    $user = trim($_GET['user']);
    $pass = trim($_GET['password']);
    $id = trim($_GET['id']);
    if (!is_numeric($id)){$key = 0;}
    else{$key = $id;}
    //
    $con = mysql_connect("localhost",$user,$pass);
    if (!$con){
        die('Error de db ' . mysql_error());
    }
    //
    mysql_select_db("TestDB",$con);
    $recordset=mysql_query("SELECT * FROM TestTable WHERE Id=" . $key);    

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