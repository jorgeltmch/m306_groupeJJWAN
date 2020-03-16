<?php
/*
    Librairie php 
    Auteur : team Rendev
    Date : 16.03.20
*/

require_once './db/EDatabase.php';


/**
  * Récupère tous les évennements (id, nom, description, date et lat long)
  */
function getEvents(){
    static $req;

    $sql =  'SELECT `idEvenement`, `nomEvenement`, `descriptionEvenement`,`dateEvent`, `latitude`,`longitude`
                FROM evenement 
                JOIN position ON `evenement`.`position_idPosition` =  `position`.`idPosition`'; 
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


/**
  * Récupère un évennement avec l'id (toutes ses infos)
  */
function getEventByID($id){

    $sql = 
    'SELECT `idEvenement`, `nomEvenement`, `descriptionEvenement`,`dateEvent`, `latitude`,`longitude`, `nomCategorie` 
    FROM evenement 
    JOIN position ON `evenement`.`position_idPosition` =  `position`.`idPosition` 
    JOIN categorie ON `evenement`.`categorie_idCategorie` =  `categorie`.`idCategorie` 
    WHERE idEvenement = :id'; 
    
        try {
            $req = EDatabase::prepare($sql); //plus rapide qu'un query
            $req->execute(
                array(
                    'id' => $id
                )

            );
        } catch (PDOException $e) {
            print "Error!: " . $e->getMessage() . "<br/>";
            die();
        }
    $result = $req->fetchAll(PDO::FETCH_ASSOC);
    return $result;
}


/**
  * Affiche l'event selectionné
  */
function displayEvent($eventAAfficher){
    $eventAAfficher = $eventAAfficher[0];

    $html = 
    "<h2>". $eventAAfficher["nomEvenement"] . "</h2> 
    <h3>". $eventAAfficher["descriptionEvenement"] . "</h3> 
    <h4> Categorie :". $eventAAfficher["nomCategorie"] . "</h4> 
    <h4> Date :". $eventAAfficher["dateEvent"] . "</h4> 
    <h4> Position Exacte :". $eventAAfficher["latitude"] . " " . $eventAAfficher["longitude"] . "</h4> 
     ";

    return $html;
}