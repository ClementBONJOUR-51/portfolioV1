<?php

/**
 * Gestion de la connexion
 *
 * PHP Version 7
 *
 * @category  PPE
 * @package   GSB
 * @author    Réseau CERTA <contact@reseaucerta.org>
 * @author    José GIL <jgil@ac-nice.fr>
 * @copyright 2017 Réseau CERTA
 * @license   Réseau CERTA
 * @version   GIT: <0>
 * @link      http://www.reseaucerta.org Contexte « Laboratoire GSB »
 */

$action = filter_input(INPUT_GET, 'action', FILTER_SANITIZE_STRING);
if (!$uc) {
    $uc = 'demandeconnexion';
}

switch ($action) {
    case 'demandeConnexion':
        include 'vues/v_connexion.php';
        break;
    case 'valideConnexion':
        $login = filter_input(INPUT_POST, 'login', FILTER_SANITIZE_STRING);
        $mdp = filter_input(INPUT_POST, 'mdp', FILTER_SANITIZE_STRING);
        $visiteur = $pdo->getInfosVisiteur($login, $mdp);

        if (!is_array($visiteur)) {   // si aucun visiteur trouv� alors je cherche du cot� des comptables ( /!\ si visiteur et comptable m�me identhifiant alors priorit� visiteur)
            $comptable = $pdo->getInfosComptable($login, $mdp);
        }



        if (!is_array($visiteur) && !is_array($comptable)) { // si aucun visiteur et comptable trouv� alors :
            ajouterErreur('Login ou mot de passe incorrect'); //erreur
            include 'vues/v_erreurs.php';
            include 'vues/v_connexion.php';
        } else {                                            // si visiteur ou comptable trouv� alors :
            if (is_array($visiteur)) {                        // si c'est un visiteur :
                $id = $visiteur['id'];
                $nom = $visiteur['nom'];
                $prenom = $visiteur['prenom'];
                $comptableBool = false;                     // l'utilisateur n'est pas comptable
                connecter($id, $nom, $prenom, $comptableBool); // j'indique dans la connection que la session n'est pas pour un comptable
                header('Location: index.php');
            } elseif (is_array($comptable)) {                  // si c'est un comptable :
                $id = $comptable['id'];
                $nom = $comptable['nom'];
                $prenom = $comptable['prenom'];
                $comptableBool = true;                     // l'utilisateur n'est pas comptable
                connecter($id, $nom, $prenom, $comptableBool); // j'indique dans la connection que la session est un comptable
                header('Location: index.php');
            }
        }
        break;
    default:
        include 'vues/v_connexion.php';
        break;
}
