namespace Messages
open System

type IEvent = interface end

type ICommand = interface end

type UserSubscriptionExpired = {    
    Date: DateTime;
    SubscriptionId: Guid;
    UserId: Guid;
} with interface IEvent

type CreateTransferTransaction = {
    TransactionId : Guid
    Amount : decimal
    SourceAccountId : Guid
    TargetAccountId : Guid
    Description : string
} with interface ICommand

type TransferTransactionCreated = {
    TransactionId : Guid
    SourceAccountId : Guid
    TargetAccountId : Guid
    Amount : decimal
    Description : string
} with interface IEvent

