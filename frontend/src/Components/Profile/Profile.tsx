import React, {useEffect, useState} from "react";
import {Button} from "react-bootstrap";
import {useNavigate} from "react-router-dom";
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
        <div>
            <div>{localization.title}</div>
            <Button className={"me-2"} variant={"success"} onClick={() => navigate("/žiadosti")}>Žiadosti</Button>
            <Button className={"me-2"} variant={"success"} onClick={() => navigate("/")}>História vstupov</Button>
        </div>
    )
}

export default ProfileComponent;