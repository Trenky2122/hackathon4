import {Button, Modal} from "react-bootstrap";
import LocalizedStrings from "react-localization";
import {useNavigate} from "react-router-dom";

// Component used to deliver successful message to user via popUp
// Prop parameter ButtonUrl is used to redirect user
// In case when ButtonUrl is empty string (""), page will be reloaded
const MessagePopUp = (props : { TitleText: string, BodyText: string, readonly ButtonText?: string , readonly ButtonUrl: string, show: boolean}) => {
    let navigate = useNavigate();
    const localization = new LocalizedStrings({
        en:{
            continue: "Continue",
        },
        sk:{
            continue: "Pokračovať",
        }
    })

    return (
        <Modal
            show={props.show}
            onHide={() => {props.ButtonUrl == "" ? window.location.reload() : navigate(props.ButtonUrl)}}
            size="lg"
            centered
        >
            <Modal.Header closeButton>
                <Modal.Title>{props.TitleText}</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <a>{props.BodyText}</a>
            </Modal.Body>
            <Modal.Footer>
                <Button variant={"success"} onClick={() => {props.ButtonUrl == "" ? window.location.reload() : navigate(props.ButtonUrl)}}>{props.ButtonText != undefined ? props.ButtonText : localization.continue}</Button>
            </Modal.Footer>
        </Modal>
    )
}

export default MessagePopUp;