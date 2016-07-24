namespace Smtp.Net.Command
{
    public enum SmtpCommandResultCode : int
    {
        None = 0,

        SystemStatus_OrSystemHelpReply = 211,
        
        HelpMessage = 214,
       
        ServiceReady = 220,
       
        ServiceClosingTransmissionChannel = 221,

        AuthenticationSuccessful = 235,

        RequestedMailActionOkay_Completed = 250,

        UserNotLocal_WillForwardTo = 251,

        CannotVerifyUser_ButWillAcceptMessageAndAttemptDelivery = 252,

        WaitingForAuthentication = 334,

        StartMailInput = 354,

        ServiceNotAvailable_ClosingTransmissionChannel = 421,

        APasswordTransitionIsNeeded = 432,

        RequestedMailActionNotTaken_MailboxUnavailable = 450,

        RequestedActionAborted_ErrorInProcessing = 451,

        TemporaryAuthenticationFailure = 454,

        SyntaxError_CommandUnrecognized = 500,

        SyntaxErrorInParametersOrArguments = 501,

        CommandNotImplemented = 502,

        BadSequenceOfCommands = 503,

        CommandParameterNotImplemented = 504,

        AuthenticationRequired = 530,

        EncryptionRequiredForRequestedAuthenticationMechanism = 538,

        RequestedActionNotTaken_MailboxUnavailable = 550,

        UserNotLocal_PleaseTry = 551,

        RequestedMailActionAborted_ExceededStorageAllocation = 552,

        RequestedActionNotTaken_MailboxNameNotAllowed = 553,

        TransactionFailed = 554
    }
}