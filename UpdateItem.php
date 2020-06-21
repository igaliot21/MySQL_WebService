<?php
    // http://192.168.1.20/webservice/UpdateItem.php?user=test&password=test&id=13&name=itemY&category=something&price=10.10
    // usuario/password
    $user     = trim($_GET['user']);
    $pass     = trim($_GET['password']);
    //
    $id       = trim($_GET['id']);
    $name     = trim($_GET['name']);
    $category = trim($_GET['category']);
    $price    = trim($_GET['price']);
    //
    $error = false;
    $error_num = 0;
    $mensaje_error = "";
    if ($id==''){
        $mensaje_error = "Id is null";
        $error_num=1;
        $error = true;
    }    
    else if ($error == false && $name==''){
        $mensaje_error = "Name is null";
        $error_num=2;
        $error = true;
    }
    else if ($error == false && $category==''){
        $mensaje_error = "Category is null";
        $error_num=3;
        $error = true;
    }
    else if ($error == false && $price==''){
        $mensaje_error = "Price is null";
        $error_num=4;
        $error = true;
    } 
    if ($error==false){
        $con = mysql_connect("localhost",$user,$pass);
        if (!$con){
            $mensaje_error = "Database error: " . mysql_error();
            $error_num=5;
            $error = true;
        }
        if ($error==false){
            //
            mysql_select_db("TestDB",$con);
            $sql = "UPDATE TestTable SET Name ='" . $name . "', Category = '" . $category . "', Price = '" . $price . "' WHERE Id=" . $id;

            if(!mysql_query($sql,$con)){
                $mensaje_error = "Database error: " . mysql_error();
                $error_num=5;
            }
            else{

                $mensaje_error = "Updated succesfully";
                $error_num=0;
            }
            mysql_close($con); 
        }
    }
    
    $datos=array();
    array_push($datos,array(
        'RC'=>$error_num,
        'Message'=>$mensaje_error,
        'Id'=>$id
    ));
    echo utf8_encode(json_encode($datos, JSON_NUMERIC_CHECK));
?>