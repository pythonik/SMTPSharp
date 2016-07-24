namespace Smtp.Net.Command
{
    public enum SMTPCommandResultCode : int
    {
        None = 0,

        SystemStatusOrSystemHelpReply = 211,
        
        HelpMessage = 214,
       
        ServiceReady = 220,
       
        ServiceClosingTransmissionChannel = 221,

        AuthenticationSuccessful = 235,

        RequestedMailActionOkay_Completed = 250,

        UserNotLocal_WillForwardTo = 251,

        CannotVerifyUserButWillAcceptMessageAndAttemptDelivery = 252,

        WaitingForAuthentication = 334,

        StartMailInput = 354,

        ServiceNotAvailableClosingTransmissionChannel = 421,

        APasswordTransitionIsNeeded = 432,

        RequestedMailActionNotTaken_MailboxUnavailable = 450,

        RequestedActionAbortedErrorInProcessing = 451,

        TemporaryAuthenticationFailure = 454,

        SyntaxErrorCommandUnrecognized = 500,

        SyntaxErrorInParametersOrArguments = 501,

        CommandNotImplemented = 502,

        BadSequenceOfCommands = 503,

        CommandParameterNotImplemented = 504,

        AuthenticationRequired = 530,

        EncryptionRequiredForRequestedAuthenticationMechanism = 538,

        RequestedActionNotTakenMailboxUnavailable = 550,

        UserNotLocalPleaseTry = 551,

        RequestedMailActionAborted_ExceededStorageAllocation = 552,

        RequestedActionNotTakenMailboxNameNotAllowed = 553,

        TransactionFailed = 554
    }
}