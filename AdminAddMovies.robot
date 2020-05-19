*** Settings ***
Documentation  This is some basic info about the whole test suite of infotiv rental car webpage
Resource       keywords_adminAddMovies.robot
Library        SeleniumLibrary

Test Setup     Begin Web Test
Test Teardown  End Web Test

*** Test Cases ***

Admin can check whether Admin can Login with the proper credentials
    [Documentation]  This is to check Admin login successfully
    [Tags]           Test1_LoginAdmin
    Login as Admin
    Verify the admin login successfully


Admin can check whether duplicate movies are not allowed to add to the list
    [Documentation]  This is to check duplicate movies are not allowed
    [Tags]           Test2_DuplicateMovies
    Verify the admin can be able to add the duplicate movies
    Verify the movie is not added successfully


Admin can check whether Admin can be able add new movies to the list
    [Documentation]  This is to check Admin can add movies
    [Tags]           Test3_AdminAbleToAddMovies
    Verify the admin can be able to add the new movies
    Verify the movie is added successfully

Admin can check whether In Stock field behaves like expected
    [Documentation]  This is to check In Stock field works as expected
    [Tags]           Test4_InStockField
    Verify the In Stock field behaviour


Admin can check the Price field with invalid inputs
    [Documentation]  This is to check Price field works as expected
    [Tags]           Test5_PriceField
    Verify the Price field with invlaid inputs


Admin can check the all mandatory fields without data leads to validation error
    [Documentation]  This is to check all mandatory fields are valid properly with validation errors
    [Tags]           Test6_AllMandatoryFieldsWithNoData
    Verify that mandatory fields without any data leads to validation error


Admin can check the Trailer field with invalid inputs
    [Documentation]  This is to check Trailer field works as expected
    [Tags]           Test7_TrailerField
    Verify the Trailer field with invlaid inputs


Admin can check the Poster URL field with invalid inputs
    [Documentation]  This is to check Poster URL field works as expected
    [Tags]           Test8_PosterURLField
    Verify the Poster URL field with invlaid inputs


Admin can check the ImDB Rating field with invalid inputs
    [Documentation]  This is to check ImDB Rating field works as expected
    [Tags]           Test9_ImDBRatingField
    Verify the ImDB Rating field with invlaid inputs

Admin can check the all mandatory fields cannot start with blank space
    [Documentation]  This is to check all mandatory fields cannot start with blank space
    [Tags]           Test10_AllMandatoryFieldsWithBlankSpace
    Verify that mandatory fields should not start with blank spaces


Admin can check the Actors Field
    [Documentation]  This is to check Actors field
    [Tags]           Test11_ActorField
    Test the Acotr field

