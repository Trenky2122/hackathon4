export enum RegistrationResultEnum
{
    Ok,
    UserExists,
    LinkExists
}

export enum RequestTypeEnum
{
    Resident,
    HandicappedResidentWorker,
    SupplyingGreen,
    ParkingPermit,
    CleaningSecurity,
    Supplying,
    Maintenance,
    ShipSupplying,
    SpecialUseOfCommunications,
    PoliceException,
    Wedding,
    Sightseeing
}

export enum RequestStateEnum{
    WaitingForApproval,
    WaitingForCompletionByUser,
    Accepted,
    Rejected
}

export interface EntranceRequestBase {
    Id: number
    State: RequestStateEnum
    Type: RequestTypeEnum,
    RequesterName: string,
    RequesterSurname: string,
    Caption: string,
    Date: Date
}
