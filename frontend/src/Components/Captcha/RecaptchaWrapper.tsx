import {Constants} from "../../Constants/Constants";
import {GoogleReCaptchaProvider} from "react-google-recaptcha-v3";
import React from "react";

const RecaptchaWrapper = (props: { InputComponent: React.FC }) => {
    return (

            <props.InputComponent />

    )
}
export default RecaptchaWrapper