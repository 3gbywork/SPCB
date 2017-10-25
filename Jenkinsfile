node {
    stage('Build'){
        bat './tools/releasebuild.bat'
    }
    stage('Test'){
        echo 'Testing...'
    }
    stage('Deploy'){
        if (currentBuild.result == null || currentBuild.result == 'SUCCESS') { 
            echo 'Deploying...'
        }
    }
}