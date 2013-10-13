(function () {
    function ScoreManager(countOfTopScores) {
        var self = this;

        if (!countOfTopScores) {
            countOfTopScores = 5;
        }


        self.displayScoreBoard = function displayScoreBoard() {
            var key;
            var localStorageLen = localStorage.length;
            if (!localStorage.length || localStorage.length === 0) {
                document.getElementById("scores").innerHTML = "Be the first to make score";
                return;
            }
            var resultHTML = "<ul>";
            for (var i = 0; i < localStorageLen; i++) {
                key = localStorage.key(i);
                resultHTML +=
                '<li>' +
                '<strong>plase</strong>: ' + (parseInt(key, 10) + 1) + '<br/>score|Player| :<strong> ' + localStorage.getItem(key) +
                '</strong></li>';
            }
            resultHTML += "</ul>";
            document.getElementById("scores").innerHTML = resultHTML;
        };

        function addPlayerToScores(key, value) {
            localStorage.setItem(key, value);
        }

        function getPlayerName() {
            var name = prompt("Well done! You menage to throw the whole trash! Please enter your name.", "anonymous");
            if (name === null) {
                name = 'anonymous';
            }
            return name;
        }


        self.updateScores = function updateScores(playerScore) {
            var playerName = getPlayerName();
            var players = [];
            var key;
            var localStorageLen = localStorage.length;
            var playerNum = localStorageLen;
            for (var i = 0; i < localStorageLen; i++) {

                key = localStorage.key(i);
                value = localStorage.getItem(key);
                if (playerScore < parseInt(value, 10)) {
                    playerNum = i;
                    break;
                }
            }
            //the player is in the last position and last from the scores
            if (playerNum === localStorageLen - 1 && playerNum === countOfTopScores - 1) {

                addPlayerToScores(playerNum, playerScore + '|' + playerName + '|');
            }
            else if (playerNum <= localStorageLen - 1) {
                var j;
                for (j = playerNum; j < localStorageLen; j++) {

                    key = localStorage.key(j);
                    value = localStorage.getItem(key);
                    players.push({ key: key, value: value });
                }
                addPlayerToScores(playerNum, playerScore + '|' + playerName + '|');
                for (j = 0; j < players.length; j++) {
                    addPlayerToScores(parseInt(players[j].key, 10) + 1, players[j].value);
                    if (localStorage.length === countOfTopScores) {
                        break;
                    }
                }
            }
                // the player is last , but there is still place for him
            else if (playerNum < countOfTopScores) {

                addPlayerToScores(playerNum, playerScore + '|' + playerName + '|');
            }
        };

        return self;
    }
    scoreManager = new ScoreManager(5);
}).call(this);