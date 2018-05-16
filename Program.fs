// Learn more about F# at http://fsharp.org

open System

open FSharp.Data

type NugetStats = HtmlProvider<"https://www.nuget.org/packages/FSharp.Data">

type Stocks = CsvProvider<"data.csv">

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"

    printfn "Some csv now..."

    // Download the stock prices
    // fails for google block
    //let msft = Stocks.Load("http://www.google.com/finance/historical?q=MSFT&output=csv")
    let msft = Stocks.Load("data_msft.csv")

    // Look at the most recent row. Note the 'Date' property
    // is of type 'DateTime' and 'Open' has a type 'decimal'
    let firstRow = msft.Rows |> Seq.head
    let lastDate = firstRow.Date
    let lastOpen = firstRow.Open

    // Print the prices in the HLOC format
    for row in msft.Rows do
      printfn "HLOC: (%A, %A, %A, %A)" row.High row.Low row.Open row.Close

    printfn "some http now.."

    let rawStats = NugetStats().Tables.``Version History``

    rawStats.Rows |> Seq.iter (printfn "row = %A")

    0 // return an integer exit code
