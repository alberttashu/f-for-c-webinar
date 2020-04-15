namespace FSharp_Types

module Types = 
   
    type BankAccount = string
    
    type Currency = USD | UAH | RUB
    
    type Money = {
        Currency : Currency;
        Dollars : int;
        Cents : int;
    }
    
    type TransferRecord = {Amount : Money; To : BankAccount}
    
    type Transaction = Income of Money | Expense of Money | Transfer of TransferRecord
    
    let processTransaction transaction =
        match transaction with 
        | Income x -> 
            let currency = x.Currency.ToString()
            printfn "Income transaction for %d.%d %s" x.Dollars x.Cents currency
        | Expense x -> 
            let currency = x.Currency.ToString()
            printfn "Expense transaction for %d.%d %s" x.Dollars x.Cents currency
        | Transfer x -> 
            let amount = x.Amount
            let currency = amount.Currency.ToString()
            printfn "Transfer of %d.%d %s to %s" amount.Dollars amount.Cents currency x.To
    
    processTransaction (Income {Dollars = 10; Cents = 20; Currency= USD})
    

