<?php

require_once './db/EDatabase.php';

function getEvents(){
    static $req;

    $sql = 'SELECT `nomEvent`, `descriptionEvent`,`dateEvent`, `latitude`,`longitude`, `nomCategorie`.`imageCategorie` FROM evenement 
                JOIN position ON `evenement`.`idPosition` =  `position`.`idPosition` 
                JOIN categorie ON `evenement`.`idCategorie` =  `categorie`.`idCategorie`; '; 
    if ($req == null) {
        try {
            $req = EDatabase::prepare($sql);
            $req->execute();
        } catch (PDOException $e) {
            print "Error!: " . $e->getMessage() . "<br/>";
            die();
        }
        
    }
    return $req->fetchAll(PDO::FETCH_ASSOC);

}