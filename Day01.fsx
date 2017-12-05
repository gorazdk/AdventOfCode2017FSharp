(*

*)

open System

// Part 1

let convertToDigits (a : char, b : char) =
  (int a - int '0', int b - int '0')

let digitize (a, b) =
  match a-b with
  | 0 -> a
  | _ -> 0

let captcha (input : string) =
  // get first element from sequence to append it at the end
  let first = Convert.ToString(Seq.head input)

  (Seq.append input first) // take input sequence and append the first element to the end
  |> Seq.pairwise // make pairs
  |> Seq.sumBy (convertToDigits >> digitize) // sum digitization

let input = "818275977931166178424892653779931342156567268946849597948944469863818248114327524824136924486891794739281668741616818614613222585132742386168687517939432911753846817997473555693821316918473474459788714917665794336753628836231159578734813485687247273288926216976992516314415836985611354682821892793983922755395577592859959966574329787693934242233159947846757279523939217844194346599494858459582798326799512571365294673978955928416955127211624234143497546729348687844317864243859238665326784414349618985832259224761857371389133635711819476969854584123589566163491796442167815899539788237118339218699137497532932492226948892362554937381497389469981346971998271644362944839883953967698665427314592438958181697639594631142991156327257413186621923369632466918836951277519421695264986942261781256412377711245825379412978876134267384793694756732246799739464721215446477972737883445615664755923441441781128933369585655925615257548499628878242122434979197969569971961379367756499884537433839217835728263798431874654317137955175565253555735968376115749641527957935691487965161211853476747758982854811367422656321836839326818976668191525884763294465366151349347633968321457954152621175837754723675485348339261288195865348545793575843874731785852718281311481217515834822185477982342271937155479432673815629144664144538221768992733498856934255518875381672342521819499939835919827166318715849161715775427981485233467222586764392783699273452228728667175488552924399518855743923659815483988899924199449721321589476864161778841352853573584489497263216627369841455165476954483715112127465311353411346132671561568444626828453687183385215975319858714144975174516356117245993696521941589168394574287785233685284294357548156487538175462176268162852746996633977948755296869616778577327951858348313582783675149343562362974553976147259225311183729415381527435926224781181987111454447371894645359797229493458443522549386769845742557644349554641538488252581267341635761715674381775778868374988451463624332123361576518411234438681171864923916896987836734129295354684962897616358722633724198278552339794629939574841672355699222747886785616814449297817352118452284785694551841431869545321438468118"



(*
  tests
*)
let test (f : string->int) ( input, res) =
  let actRes = f input

  match (res, actRes) with
  | (a, b) when a = b -> printfn "OK (%s)" input
  | (a, b) -> printfn "ER %A <> %A (%s)" a b input

let test1 = test captcha

test1 ("1122", 3)
test1 ("1111", 4)
test1 ("1234", 0)
test1 ("91212129", 9)
test1 (input, 1097)

// Part 2
let captcha2 (input : string) =
  let len = input.Length;
  
  let left = input.Substring(0, len / 2)
  let right = input.Substring(len / 2, len / 2)

  (Seq.zip left right)
  |> Seq.sumBy (convertToDigits >> digitize >> (*) 2) // sum digitization
  

let test2 = test captcha2

captcha2 input

test2 ("1212", 6)  
test2 ("1221", 0)  
test2 ("123425", 4)  
test2 ("123123", 12)  
test2 ("12131415", 4)  
test2 (input, 1188)
