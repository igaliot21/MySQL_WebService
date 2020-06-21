<?php
    // http://192.168.1.20/webservice/AddItem.php?user=test&password=test&name=itemX&category=something&price=10.10
    // usuario/password
    $user     = trim($_GET['user']);
    $pass     = trim($_GET['password']);
    //
    $name     = trim($_GET['name']);
    $category = trim($_GET['category']);
    $price    = trim($_GET['price']);
    //
    $error = false;
    $error_num = 0;
    $mensaje_error = "";
    if ($name==''){
        $mensaje_error = "Name is null";
        $error_num=1;
        $error = true;
    }
    else if ($error == false && $category==''){
        $mensaje_error = "Category is null";
        $error_num=2;
        $error = true;
    }
    else if ($error == false && $price==''){
        $mensaje_error = "Price is null";
        $error_num=3;
        $error = true;
    } 
    if ($error==false){
        $con = mysql_connect("localhost",$user,$pass);
        if (!$con){
            $mensaje_error = "Database error: " . mysql_error();
            $error_num=4;
            $error = true;
        }
        if ($error==false){
            //
            mysql_select_db("TestDB",$con);
            $sql = "INSERT INTO TestTable (Id, Name, Category, Price) VALUES (NULL, '" . $name . "','" . $category . "','" . $price . "')";

            if(!mysql_query($sql,$con)){
                $mensaje_error = "Database error: " . mysql_error();
                $error_num=4;
            }
            else{
                $recordset=mysql_query("SELECT MAX(Id) FROM TestTable");
                while($row = mysql_fetch_array($recordset)){
                    $newid = $row['MAX(Id)'];
                }
                $mensaje_error = "Added succesfully";
                $error_num=0;
            }
            mysql_close($con); 
        }
    }
    
    $datos=array();
    array_push($datos,array(
        'RC'=>$error_num,
        'Message'=>$mensaje_error,
        'Id'=>$newid
    ));
    echo utf8_encode(json_encode($datos, JSON_NUMERIC_CHECK));
?>