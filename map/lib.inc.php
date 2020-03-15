<?php

require_once './db/EDatabase.php';



function getEvents(){
    static $req;

    $sql = 'SELECT `idEvenement`, `nomEvenement`, `descriptionEvenement`,`dateEvent`, `latitude`,`longitude`, `nomCategorie`, `imageCategorie` FROM evenement 
                JOIN position ON `evenement`.`position_idPosition` =  `position`.`idPosition` 
                JOIN categorie ON `evenement`.`categorie_idCategorie` =  `categorie`.`idCategorie`; '; 
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

