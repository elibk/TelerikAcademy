(function () {
    function ScoreManager(countOfTopScores) {
        var self = this;
        var nameOfScores = "RecyclingGameScores";

        if (!countOfTopScores) {
            countOfTopScores = 5;
        }


        self.displayScoreBoard = function displayScoreBoard() {
            var scores = localStorage.getObject(nameOfScores);
            
            if (!scores || scores.length === 0) {
                
                document.getElementById("scores").innerHTML = "Be the first to make score";
                return;

            }
           
            var resultHTML = "<ul>";
            for (var i = 0; i < scores.length; i += 1) {
                resultHTML +=
                '<li>' +
                '<strong>plase</strong>: ' + (i + 1) + '<br/>score :<strong> ' + scores[i].score + "</strong> player: <strong>" + scores[i].player +
                '</strong></li>';
            }
            resultHTML += "</ul>";
            document.getElementById("scores").innerHTML = resultHTML;
        };

        function getPlayerName() {
            var name = prompt("Well done! You menage to throw the whole trash! Please enter your name.", "anonymous");
            if (name === null) {
                name = 'anonymous';
            }
            return name;
        }

        function orderBy(a, b) {
            return (a.score === b.score) ? 0 : (a.score > b.score) ? 1 : -1;
        }

        self.updateScores = function updateScores(playerScore) {
            var playerName = getPlayerName();
            var scores = localStorage.getObject(nameOfScores);

            if (!scores) {
                scores = [];
            }

            scores.push({ player: playerName, score: playerScore });

            scores.sort(orderBy);

            if (scores.length > countOfTopScores) {

                scores.pop();
            }

            localStorage.setObject(nameOfScores, scores);
        };

        return self;
    }
    scoreManager = new ScoreManager(5);
}).call(this);