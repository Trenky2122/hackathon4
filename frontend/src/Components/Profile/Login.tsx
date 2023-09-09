import React, {useCallback, useState} from "react";
import {Button} from "react-bootstrap";
import {useNavigate} from "react-router-dom";
import LocalizedStrings from "react-localization";
import TextField from "@material-ui/core/TextField";
import MessagePopUp from "../PopUp/MessagePopUp";
import {useGoogleReCaptcha} from "react-google-recaptcha-v3";
import {UtilService} from "../../Service/UtilService";

const LoginComponent = () => {
    let navigate = useNavigate();
    let [email, setEmail] : [string, any] = useState("");
    let [password, setPassword] : [string, any] = useState("");
    let [errorMessage, setErrorMessage] : [string, any] = useState("");
    let [loginError, setLoginError] : [boolean, any] = useState(false);

    const actionName: string = "login";

    const localization = new LocalizedStrings({
        en: {
            title: "Login",
        },
        sk: {
            title: "Prihlásenie",
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
                // Zavolaj backend endpoint aby si zistil ci su prihlasovacie udaje spravne
                if(password == "admin") {
                    localStorage.setItem("loggedIn", "true")
                    navigate("/profil")
                }
                else {
                    setLoginError(true)
                }
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
                            <h1 style={{marginBottom: "30px"}}>Prihlásenie</h1>
                            <TextField label={"Email"} required autoFocus value={email}
                                       onChange={(e) => {
                                           setEmail(e.target.value);
                                           setErrorMessage("");
                                       }} fullWidth type={"email"} />
                            <TextField label={"Heslo"} required value={password}
                                       onChange={(e) => {
                                           setPassword(e.target.value);
                                           setErrorMessage("");
                                       }} fullWidth type={"password"} />
                            <Button className={"me-2 mt-3"} type={"submit"} variant={"success"}>Prihlásiť sa</Button>
                        </form>
                    </div>
                </div>
            </div>
            <MessagePopUp
                TitleText={"Chyba"}
                BodyText={"Nesprávne prihlasovacie meno alebo heslo. Skúste znovu."}
                ButtonUrl={""}
                ButtonText={"Skúsiť znovu"}
                show={loginError}
            />
        </div>
    )
}

export default LoginComponent;