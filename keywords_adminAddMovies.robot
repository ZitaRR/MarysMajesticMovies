*** Settings ***
Library     SeleniumLibrary
Library     Collections
Library     String

*** Variables ***
${BROWSER} =  chrome
${URL} =      https://localhost:44304/


*** Keywords ***
Begin Web Test
    Open Browser                about:blank   ${BROWSER}
    Maximize Browser Window
    Go To                       ${URL}


Login as Admin
    Click Link                  xpath://*[@id="mainpagebody"]/footer/div[3]/p/a[1]
    Input Text                  id:Input_Email              admin@admin.com
    Input Text                  id:Input_Password           Passw0rd123!
    execute javascript  window.scrollTo(0,document.body.scrollHeight)
    Click Element               xpath://*[@id="mainpagebody"]/div/main/div[2]/form/input[3]

Verify the admin login successfully
    ${admin_text}       Get Text            xpath://*[@id="mainpagebody"]/footer/h3
    Should Be Equal      ${admin_text}       You're logged in as Admin!

Open Admin Page
    Login as Admin
    Click Link      xpath://*[@id="mainpagebody"]/header/div/a[5]

Verify the admin can be able to add the duplicate movies
    Open Admin Page
    Input Text      id:SearchMovieInput_ImdbId                      tt0109830
    Click Element   xpath://*[@id="mainpagebody"]/div/main/div/form[1]/input[2]

    Input Text      id:AddMovieInput_ImdbId         tt0109830
    Input Text      id:AddMovieInput_Title          Forrest Gump
    Input Text      id:AddMovieInput_Year           1994
    #trim length
    #${length}       Get Text         id:AddMovieInput_RunTime
    #${len} =        Remove String    ${length}      min
    Input Text      id:AddMovieInput_RunTime        142

    Input Text      id:AddMovieInput_Genre          Drama, Romance
    Input Text      id:AddMovieInput_Director       Robert Zemeckis
    Input Text      id:AddMovieInput_Actors         Tom Hanks, Rebecca Williams, Sally Field, Michael Conner Humphreys
    Input Text      id:AddMovieInput_Plot           The presidencies of Kennedy and Johnson, the events of Vietnam, Watergate and other historical events unfold through the perspective of an Alabama man with an IQ of 75, whose only desire is to be reunited with his childhood sweetheart.
    Input Text      id:AddMovieInput_ImdbRating     8.8
    Input Text      id:AddMovieInput_PosterUrl      https://m.media-amazon.com/images/M/MV5BNWIwODRlZTUtY2U3ZS00Yzg1LWJhNzYtMmZiYmEyNmU1NjMzXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_SX300.jpg
    Input Text      id:AddMovieInput_TrailerUrl     https://www.imdb.com/video/vi3567517977?playlistId=tt0109830&ref_=tt_ov_vi
    Input Text      id:AddMovieInput_Price          200
    Input Text      id:AddMovieInput_InStock        3

    execute javascript  window.scrollTo(0,document.body.scrollHeight)
    Click Element   xpath://*[@id="mainpagebody"]/div/main/div/form[2]/input[14]


Verify the movie is not added successfully
    Page Should Contain       Movie is already registered, please try another one


Verify the admin can be able to add the new movies
    Open Admin Page
    Input Text      id:SearchMovieInput_ImdbId                      tt8420184
    Click Element   xpath://*[@id="mainpagebody"]/div/main/div/form[1]/input[2]
    #trim length
    ${length}       Get Value         id:AddMovieInput_RunTime
    ${len} =        Remove String     ${length}     min
    Input Text      id:AddMovieInput_RunTime        ${len}

    Input Text      id:AddMovieInput_TrailerUrl     https://www.imdb.com/video/vi3567517977?playlistId=tt0109830&ref_=tt_ov_vi
    Input Text      id:AddMovieInput_Price          260
    Input Text      id:AddMovieInput_InStock        31

    execute javascript  window.scrollTo(0,document.body.scrollHeight)
    Click Element   xpath://*[@id="mainpagebody"]/div/main/div/form[2]/input[14]


Verify the movie is added successfully
    Page Should Contain       Movie is registered!


Verify the In Stock field behaviour
    Open Admin Page
    Input Text      id:AddMovieInput_InStock    abcdef
    Press Keys      id:AddMovieInput_InStock    TAB
    #Page Should Contain     The IMDb rate is between 0-10000

    ${InStock_error}     Get Text    id:AddMovieInput_InStock-error
    should be equal     ${InStock_error}     The IMDb rate is between 0-10000
    Input Text      id:AddMovieInput_InStock    A#¤#%1#¤/(
    Press Keys      id:AddMovieInput_InStock    TAB

    ${InStock_error}     Get Text    id:AddMovieInput_InStock-error
    should be equal     ${InStock_error}     The IMDb rate is between 0-10000
    Input Text      id:AddMovieInput_InStock    10001
    Press Keys      id:AddMovieInput_InStock    TAB
    Page Should Contain     The IMDb rate is between 0-10000


Verify the Price field with invlaid inputs
    Open Admin Page
    Input Text      id:AddMovieInput_Price      abcdef
    Press Keys      id:AddMovieInput_Price      TAB
    ${price_error}  Get Text        id:AddMovieInput_Price-error
    Should Be Equal     ${price_error}      The field Price must be a number.

    Input Text      id:AddMovieInput_Price      1500
    Press Keys      id:AddMovieInput_Price      TAB
    ${price_error}  Get Text        id:AddMovieInput_Price-error
    Should Be Equal     ${price_error}      The price can only be betweeen 1-1000 kr

Verify the Trailer field with invlaid inputs
    Open Admin Page
    Input Text      id:AddMovieInput_TrailerUrl      abcdef
    Press Keys      id:AddMovieInput_TrailerUrl      TAB
    ${trailer_error}  Get Text        id:AddMovieInput_TrailerUrl-error
    Should Be Equal     ${trailer_error}      The Trailer url field is not a valid fully-qualified http, https, or ftp URL.

    Input Text      id:AddMovieInput_TrailerUrl      123456
    Press Keys      id:AddMovieInput_TrailerUrl      TAB
    ${trailer_error}  Get Text        id:AddMovieInput_TrailerUrl-error
    Should Be Equal     ${trailer_error}      The Trailer url field is not a valid fully-qualified http, https, or ftp URL.

    Input Text      id:AddMovieInput_TrailerUrl      http://abc.123.co.ab123
    Press Keys      id:AddMovieInput_TrailerUrl      TAB
    ${trailer_error}  Get Text        id:AddMovieInput_TrailerUrl-error
    Should Be Equal     ${trailer_error}      The Trailer url field is not a valid fully-qualified http, https, or ftp URL.


Verify the Poster URL field with invlaid inputs
    Open Admin Page
    Input Text      id:AddMovieInput_PosterUrl      abcdef
    Press Keys      id:AddMovieInput_PosterUrl      TAB
    ${poster_error}  Get Text        id:AddMovieInput_PosterUrl-error
    Should Be Equal     ${poster_error}      The Poster url field is not a valid fully-qualified http, https, or ftp URL.

    Input Text      id:AddMovieInput_PosterUrl      123456
    Press Keys      id:AddMovieInput_PosterUrl      TAB
    ${poster_error}  Get Text        id:AddMovieInput_PosterUrl-error
    Should Be Equal     ${poster_error}      The Poster url field is not a valid fully-qualified http, https, or ftp URL.

    Input Text      id:AddMovieInput_PosterUrl      http:/sadsa.com
    Press Keys      id:AddMovieInput_PosterUrl      TAB
    ${poster_error}  Get Text        id:AddMovieInput_PosterUrl-error
    Should Be Equal     ${poster_error}      The Poster url field is not a valid fully-qualified http, https, or ftp URL.


Verify the ImDB Rating field with invlaid inputs
    Open Admin Page
    Input Text      id:AddMovieInput_ImdbRating      abcdef
    Press Keys      id:AddMovieInput_ImdbRating      TAB
    ${rating_error}  Get Text        id:AddMovieInput_ImdbRating-error
    Should Be Equal     ${rating_error}      The field Imdb Rating must be a number.

    Input Text      id:AddMovieInput_ImdbRating      &/##¤!(
    Press Keys      id:AddMovieInput_ImdbRating      TAB
    ${rating_error}  Get Text        id:AddMovieInput_ImdbRating-error
    Should Be Equal     ${rating_error}      The field Imdb Rating must be a number.

    Input Text      id:AddMovieInput_ImdbRating      12
    Press Keys      id:AddMovieInput_ImdbRating      TAB
    ${rating_error}  Get Text        id:AddMovieInput_ImdbRating-error
    Should Be Equal     ${rating_error}      IMDb Rate is a number between 0-10



Verify that mandatory fields without any data leads to validation error
    Open Admin Page

    Input Text      id:AddMovieInput_ImdbId         ${EMPTY}
    Input Text      id:AddMovieInput_Title          ${EMPTY}
    Input Text      id:AddMovieInput_Year           ${EMPTY}
    Input Text      id:AddMovieInput_RunTime        ${EMPTY}

    Input Text      id:AddMovieInput_Genre          ${EMPTY}
    Input Text      id:AddMovieInput_Director       ${EMPTY}
    Input Text      id:AddMovieInput_Actors         ${EMPTY}
    Input Text      id:AddMovieInput_Plot           ${EMPTY}
    Input Text      id:AddMovieInput_ImdbRating     ${EMPTY}
    Input Text      id:AddMovieInput_PosterUrl      ${EMPTY}
    Input Text      id:AddMovieInput_TrailerUrl     ${EMPTY}
    Input Text      id:AddMovieInput_Price          ${EMPTY}
    Input Text      id:AddMovieInput_InStock        ${EMPTY}

    execute javascript  window.scrollTo(0,document.body.scrollHeight)
    Click Element   xpath://*[@id="mainpagebody"]/div/main/div/form[2]/input[14]

    Page Should Contain     The Imdb id field is required.
    Page Should Contain     The Movie titel field is required.
    Page Should Contain     The Release year field is required.
    Page Should Contain     The Movie length field is required.
    Page Should Contain     The Release year field is required.
    Page Should Contain     The Movie length field is required.
    Page Should Contain     The Genre field is required.
    Page Should Contain     The Director field is required.
    Page Should Contain     The Actors field is required.
    Page Should Contain     The Plot field is required.
    Page Should Contain     The Imdb Rating field is required.
    Page Should Contain     The Poster url field is required.
    Page Should Contain     The Trailer url field is required.
    Page Should Contain     The Price field is required.
    Page Should Contain     The In stock field is required.



Verify that mandatory fields should not start with blank spaces
    Open Admin Page

    Input Text      id:AddMovieInput_ImdbId         ${SPACE}tt0109830
    Input Text      id:AddMovieInput_Title          ${SPACE}vvgh
    Input Text      id:AddMovieInput_Year           ${SPACE}1867
    Input Text      id:AddMovieInput_RunTime        ${SPACE}234

    Input Text      id:AddMovieInput_Genre          ${SPACE}He is a good boy.
    Input Text      id:AddMovieInput_Director       ${SPACE}Kenny
    Input Text      id:AddMovieInput_Actors         ${SPACE}KRistof
    Input Text      id:AddMovieInput_Plot           ${SPACE}The president of UK is..
    Input Text      id:AddMovieInput_ImdbRating     ${SPACE}5.5
    Input Text      id:AddMovieInput_PosterUrl      ${SPACE}http://abc.in
    Input Text      id:AddMovieInput_TrailerUrl     ${SPACE}http://abc.in
    Input Text      id:AddMovieInput_Price          ${SPACE}234
    Input Text      id:AddMovieInput_InStock        ${SPACE}45

    execute javascript  window.scrollTo(0,document.body.scrollHeight)
    Click Element   xpath://*[@id="mainpagebody"]/div/main/div/form[2]/input[14]

    Page Should Contain     Imdb id format is "tt123..."
    Page Should Contain     Title can not start with a blank space
    #Page Should Contain     Year can not start with a blank space
    #Page Should Contain     Length can not start with a blank space
    Page Should Contain     Genre can not start with a blank space
    Page Should Contain     Director can not start with a blank space
    Page Should Contain     Actors can not start with a blank space
    Page Should Contain     Plot can not start with a blank space
    Page Should Contain     The field Imdb Rating must be a number.
    Page Should Contain     The Poster url field is not a valid fully-qualified http, https, or ftp URL.
    Page Should Contain     The Trailer url field is not a valid fully-qualified http, https, or ftp URL.
    Page Should Contain     The field Price must be a number.
    Page Should Contain     In stock is a number between 0-10000


Test the Acotr field
     Open Admin Page

     Input Text    id:AddMovieInput_Actors     ${SPACE}
     Press Keys    id:AddMovieInput_Actors     TAB
     ${link_text}  Get Text    id:AddMovieInput_Actors-error
     Should Be Equal     ${link_text}   Actors can not start with a blank space


End Web Test
    Sleep         2s
    Close Browser


