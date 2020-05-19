pipeline {
    agent any
     stages {
        stage('Checkout') {
            steps {
                git 'https://github.com/ZitaRR/MarysMajesticMovies.git'
             }
         }
        
        stage('Restore Packages') {
            steps {
              bat "dotnet restore"
            }
        }
        
       stage('Build') {
     	steps {
    	     bat 'dotnet build MarysMajesticMovies.sln'
     	}
       }	
        stage('Pack') {
   	steps {
    	    bat 'dotnet pack --no-build --output nupkgs'
   	}
      }
       stage('Run') {
            steps {
                bat 'START /B dotnet C:/Users/rajani/.jenkins/workspace/MM_Movies/MarysMajesticMovies/bin/Debug/netcoreapp3.1/MarysMajesticMovies.dll'
            }
        }
        stage('UI tests') {
            steps {
                   
                    bat 'robot C:/Users/rajani/PycharmProjects/MM_MoviesRF/Tests/*..robot'
            }
        }
     }
     
    
 }