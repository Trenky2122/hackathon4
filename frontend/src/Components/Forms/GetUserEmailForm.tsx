import React, {useCallback, useState} from "react";
import {Button} from "react-bootstrap";
import {useNavigate} from "react-router-dom";
import TextField from "@material-ui/core/TextField";
import MessagePopUp from "../PopUp/MessagePopUp";
import {RegistrationResultEnum} from "../../Models/Models";
import {useGoogleReCaptcha} from "react-google-recaptcha-v3";
import {UtilService} from "../../Service/UtilService";

const GetUserEmailForm = () => {
    let navigate = useNavigate();
    let [email, setEmail] : [string, any] = useState("");
    let [serverResponse, setServerResponse] : [any, any?] = useState(null);
    const actionName: string = "user_email";
    const localization = new LocalizedStrings({
        en: {
            title: "Get user email",
        },
        sk: {
            title: "Zadajte Váš email",
        }
    });
    const { executeRecaptcha } = useGoogleReCaptcha();

    const processRecaptcha = async (): Promise<boolean> => {
        let token = await getRecaptchaToken();
        return await UtilService.verifyReCaptchaToken(token, actionName);
    }

    const getRecaptchaToken = useCallback(async (): Promise<string> => {
            return await UtilService.getRecaptchaToken(executeRecaptcha!, actionName)
    }, [executeRecaptcha]);

    const handleSubmit = (e: any) => {
        e.preventDefault()
        processRecaptcha().then((res) =>{
            if(res){
                console.log("Posielam mail na", email)
                // Zavolaj backend endpoint s parametrom mail
                // Backend endpiont nech vytvori gui, a prida data ako mail, cas, gui do tabulky
                setServerResponse(RegistrationResultEnum.Ok)
            }
        }).catch((e) => {
            console.log(e)
        });
    }

    return (
        <div>
            <div className={"container"}>
                <div className={"row justify-content-center"} >
                    <div className={"col-3 homepageForm"}>
                        <form onSubmit={handleSubmit}>
                        <h1 style={{marginBottom: "30px"}}>Zadajte Váš email</h1>
                            <TextField className={"mb-4"} label={"Email"} required value={email}
                                       onChange={(e) => {
                                           setEmail(e.target.value);
                                       }} type={"email"} fullWidth={true} />
                            <Button className={"me-2"} variant={"danger"} onClick={() => navigate("/")}>Zrušiť</Button>
                            <Button className={"me-2"} type={"submit"} variant={"success"}>Over mail</Button></form>
                    </div>
                </div>
            </div>
            <MessagePopUp
                TitleText={"Email poslaný"}
                BodyText={"Email s unikátnym linkom Vám bol odoslaný na mailovú adresu. Link má dobu expirácie 1 deň."}
                ButtonUrl={"/"}
                ButtonText={"Domov"}
                show={serverResponse === RegistrationResultEnum.Ok}
            />
            <MessagePopUp
                TitleText={"Link je vygenerovaný"}
                BodyText={"Aktuálne už máte vygenerovaný unikátny link. Pozrite si mail."}
                ButtonUrl={"/"}
                ButtonText={"Domov"}
                show={serverResponse === RegistrationResultEnum.LinkExists}
            />
            <MessagePopUp
                TitleText={"Link je vygenerovaný"}
                BodyText={"Aktuálne už máte vygenerovaný unikátny link. Pozrite si mail."}
                ButtonUrl={"/"}
                ButtonText={"Domov"}
                show={serverResponse === RegistrationResultEnum.UserExists}
            />
        </div>
    )
}

export default GetUserEmailForm;