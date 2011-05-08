properties { 
	$projectName = "StyleCopPlus"
	$rootDir  = Resolve-Path ..\
	$buildOutputDir = "$rootDir\build"
	$solutionFile = "$rootDir\$projectName.sln"
}

task default -depends Clean, CopyBuildOutput

task Clean {
	Clean $buildOutputDir $solutionFile
}

task Compile { 
	exec { msbuild $solutionFile /p:Configuration=Release }
}

task CopyBuildOutput -depends Compile {
	New-Item $buildOutputDir -Type directory
	Copy-Item $rootDir\$projectName\bin\Release\$projectName.dll $buildOutputDir
}

function Clean
{
	param
	(
		[string]$buildOutputDir,
		[string]$solutionFilePath
	)
	$command = { Remove-Item $buildOutputDir -Force -Recurse }
	$commandName = "Delete content of [$buildOutputDir]"
	
	if ( (Test-Path -Path $buildOutputDir -PathType Container) -eq $true){
		Execute-CommandWithRetry -Command $command -CommandName $commandName
		$error.Clear() # workaround for any file system errors when cleaning the build dir (we don't care about them)
	}
	if($cleanBuild -eq $true){
		exec { msbuild $solutionFilePath /t:Clean }
	}
}

function Execute-CommandWithRetry($Command,$CommandName)
{
    $currentRetry = 0;
    $success = $false;
    
    do
    {
        try
        {
            & $Command;
            $success = $true;
        }
        catch [System.Exception]
        {
            $message = 'Exception occurred while trying to execute [$CommandName] command:' + $_.Exception.ToString();   
            if ($currentRetry -gt 5)
            {                             
                $message = "Can not execute [$CommandName] command. The error: " + $_.Exception.ToString();
                throw $message;
            }
            else
            {
               Start-Sleep -s 1;
            }
            $currentRetry = $currentRetry + 1;
        }
    } 
    while (!$success);   
}