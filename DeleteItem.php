<?php
    // http://192.168.1.20/webservice/DeleteItem.php?user=test&password=test&id=13
    // usuario/password
    $user     = trim($_GET['user']);
    $pass     = trim($_GET['password']);
    //
    $id       = trim($_GET['id']);
    //
    $error = false;
    $error_num = 0;
    $mensaje_error = "";
    if ($id==''){
        $mensaje_error = "Id is null";
        $error_num=1;
        $error = true;
    }
    if ($error==false){
        $con = mysql_connect("localhost",$user,$pass);
        if (!$con){
            $mensaje_error = "Database error: " . mysql_error();
            $error_num=2;
            $error = true;
        }
        if ($error==false){
            //
            mysql_select_db("TestDB",$con);
            $sql = "DELETE FROM TestTable WHERE Id=" . $id;

            if(!mysql_query($sql,$con)){
                $mensaje_error = "Database error: " . mysql_error();
                $error_num=2;
            }
            else{
                $mensaje_error = "Deleted succesfully";
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