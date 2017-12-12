
(*
    ltttttttt
    l       r
    l  0,0  r
    l       r 
    bbbbbbbbbr
*)
let isRight (x, y) =
  (x > 0 && x > abs(y))

let isBottom (x, y) =
  y >= 0 && y >= abs(x)

let isLeft (x, y) =
  x < 0 && -x >= abs(y) && -x > y

let moveNext (x, y) =
  match (x, y) with
  | (a, b) when isBottom(a, b) -> (a+1, b)
  | (a, b) when isRight(a, b) -> (a, b-1)
  | (a, b) when isLeft(a, b) -> (a, b+1)
  | (a, b)  -> (a-1, b)

let manhattanDistance (x, y) = 
  abs(x) + abs(y)

{2..361527}
|> Seq.fold (fun (x, y) _ -> moveNext (x, y))  (0, 0)
|> manhattanDistance
|> (=) 326

// Part II


(*
            1

            1    1

                 2
            1    1

            4    2
            1    1

       5    4    2
            1    1

       5    4    2
      10    1    1

       5    4    2
      10    1    1
      11

       5    4    2
      10    1    1
      11   23

       5    4    2
      10    1    1
      11   23   25

       5    4    2
      10    1    1
      11   23   25   26

       5    4    2
      10    1    1   54
      11   23   25   26


       5    4    2   59
      10    1    1   54
      11   23   25   26

    ltttttttt
    l       r
    l  0,0  r
    l       r  
    bbbbbbbbbr 
               
*)

let moveNext (x, y) =
  match (x, y) with
  | (a, b) when isBottom(a, b) -> (a+1, b)
  | (a, b) when isRight(a, b) -> (a, b-1)
  | (a, b) when isLeft(a, b) -> (a, b+1)
  | (a, b)  -> (a-1, b)

let movePrev (x,y) =
  [|
    (-1, 0)
    (1, 0)
    (0, -1)
    (0, 1)
  |]
  |> Array.filter(fun (dx, dy) -> (x,y)=moveNext(x+dx, y+dy))
  |> Array.map(fun (dx, dy) -> (x+dx,y+dy))
  |> Array.head


let adjacentSquares (x, y) =

  let next = moveNext(x, y)
  [|
    (0,1)
    (0,-1)
    (1,0)
    (1,-1)
    (1,1)
    (-1,0)
    (-1,1)
    (-1,-1)
  |]
  |> Array.filter (fun (dx, dy) -> abs(dx+x) <= abs(x) && abs(dy+y) <= abs(y))
  |> Array.filter (fun (dx, dy) -> (dx+x, dy+y) <> next)
  |> Array.map (fun (dx, dy) -> (dx+x, dy+y))


(0,0)
|> moveNext
|> moveNext
|> moveNext
(0,-2)
|> adjacentSquares
