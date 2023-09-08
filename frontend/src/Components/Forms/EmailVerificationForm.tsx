import React, {useState} from "react";
import {Button} from "react-bootstrap";
import {useNavigate} from "react-router-dom";
import LocalizedStrings from "react-localization";
import TextField from "@material-ui/core/TextField";

const EmailVerificationForm = () => {
    let navigate = useNavigate();
    let [verificationCode, setVerificationCode] : [string, any] = useState("");
    let [email, setEmail] : [string, any] = useState("");
    const localization = new LocalizedStrings({
        en: {
            title: "Email verification",
        },
        sk: {
            title: "Verifikácia emailu",
        }
    });
    return (
        <div>
            <div>{localization.title}</div>
            <TextField style={{width: 500}} label={"Verifikačńý kód"} required autoFocus value={verificationCode}
                onChange={(e) => {
                    setVerificationCode(e.target.value)
                }}/>
            <Button className={"me-2"} variant={"success"} onClick={() => navigate("/poziadanieVstupu/ziskanieUdajov")}>Ďalej</Button>
        </div>
    )
}

export default EmailVerificationForm;