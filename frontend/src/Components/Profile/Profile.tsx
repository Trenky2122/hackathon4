import React, {useEffect, useState} from "react";
import {Button} from "react-bootstrap";
import {Link, useNavigate} from "react-router-dom";
import LocalizedStrings from "react-localization";

const ProfileComponent = () => {
    let navigate = useNavigate();
    const localization = new LocalizedStrings({
        en: {
            title: "User profile",
        },
        sk: {
            title: "Konto používateľa",
        }
    });

    useEffect(() => {
        //
    },  [])

    return (
        <div className={"container"}>
            <div className={"row justify-content-center"} >
                <div className={"col-3 homepageForm"}>
                    <h1 style={{marginBottom: "30px"}}>{localization.title} </h1>
                    <Button className={"me-2"} variant={"success"} onClick={() => navigate("/profil/ziadosti")}>Žiadosti</Button>
                    <Button className={"me-2"} variant={"success"} onClick={() => navigate("/profil/historiaVstupov")}>História vstupov</Button>
                    <Button className={"me-2"} variant={"danger"} onClick={() => navigate("/")}>Odhlásiť sa</Button>
                </div>
            </div>
        </div>
    )
}

export default ProfileComponent;