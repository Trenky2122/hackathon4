import React, {useEffect} from "react";
import {Button} from "react-bootstrap";
import {useNavigate} from "react-router-dom";
import { Utils } from "../../Service/Utils";

const ProfileComponent = () => {
    let navigate = useNavigate();

    useEffect(() => {
        if(!Utils.UserIsLogged()){
            navigate("/401");
        }
    },  [])

    return (
        <div className={"container"}>
            <div className={"row justify-content-center"} >
                <div className={"col-3 homepageForm"}>
                    <h1 style={{marginBottom: "30px"}}>Konto používateľa</h1>
                    <Button className={"me-2"} variant={"success"} onClick={() => navigate("/profil/ziadosti")}>Žiadosti</Button>
                    <Button className={"me-2"} variant={"success"} onClick={() => navigate("/profil/historiaVstupov")}>História vstupov</Button>
                    <Button className={"me-2"} variant={"danger"} onClick={() => {localStorage.removeItem("loggedIn"); navigate("/")}}>Odhlásiť sa</Button>
                </div>
            </div>
        </div>
    )
}

export default ProfileComponent;