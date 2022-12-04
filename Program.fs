open System.IO

let lines = File.ReadAllLines "/tmp/aoc/input" |> Array.toList

let parse (line:string) =
    let pair = line.Split [|','|]
    let pair1 = pair[0].Split [|'-'|]
    let pair2 = pair[1].Split [|'-'|]
    ((pair1[0] |> int,pair1[1] |> int),(pair2[0] |> int, pair2[1] |> int))

let parsed = lines |> List.map parse

let expand (((x1,x2),(x3,x4)): (int*int)*(int*int)) =
    ([x1..x2] |> Set.ofList, [x3..x4] |> Set.ofList)
let expanded = parsed |> List.map expand

let contained ((s1,s2):Set<int>*Set<int>) =
    let is = Set.intersect s1 s2
    is.IsEmpty |> not
    // is = s1 || is = s2

let a1 = expanded |> List.filter contained |> List.length 

parsed |> List.map (printfn "%A")

printfn $"{a1}"