import React, {useEffect} from "react";
import {Button} from "react-bootstrap";
import {useNavigate} from "react-router-dom";
import {UtilService} from "../../Service/UtilService";

const UserEntriesHistoryComponent = () => {
    let navigate = useNavigate();

    useEffect(() => {
        if(!UtilService.UserIsLogged()){
            navigate("/401");
        }
        else{
            // Zavolaj backend service aby si dostal dáta o posledných vstupoch o používateľovi
            // Dáta: kde, kedy vosiel, kedy odisiel, straveny cas dnu, poplatok, stav zaplatenia
        }
    },  [])

    return (
        <div className={"container"}>
            <div className={"row justify-content-center"} >
                <div className={"col-3 homepageForm"}>
                    <h1 style={{marginBottom: "30px"}}>História vstupov používateľa</h1>
                    <p>Neevidujeme vstupy</p>
                    <Button className={"me-2"} variant={"success"} onClick={() => navigate("/profil")}>Profil</Button>
                </div>
            </div>
        </div>
    )
}

export default UserEntriesHistoryComponent;