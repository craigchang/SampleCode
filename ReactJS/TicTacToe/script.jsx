// Code goes here
'use strict'

function checkWinCondition(board) {
  return (board[0][0] == board[0][1] && board[0][1] == board[0][2] && (board[0][0] == "X" || board[0][0] == "O")) ||
    (board[1][0] == board[1][1] && board[1][1] == board[1][2] && (board[1][0] == "X" || board[1][0] == "O")) ||
    (board[2][0] == board[2][1] && board[2][1] == board[2][2] && (board[2][0] == "X" || board[2][0] == "O")) ||
    (board[0][0] == board[1][0] && board[1][0] == board[2][0] && (board[0][0] == "X" || board[0][0] == "O")) ||
    (board[0][1] == board[1][1] && board[1][1] == board[2][1] && (board[0][1] == "X" || board[0][1] == "O")) ||
    (board[0][2] == board[1][2] && board[1][2] == board[2][2] && (board[0][2] == "X" || board[0][2] == "O")) ||
    (board[0][0] == board[1][1] && board[1][1] == board[2][2] && (board[0][0] == "X" || board[0][0] == "O")) ||
    (board[2][0] == board[1][1] && board[1][1] == board[0][2] && (board[2][0] == "X" || board[2][0] == "O"));
}

var Main = React.createClass({
  getInitialState: function() {
    return {
      board: this.getInitialBoard(),
      currentPlayer: 'O',
      players: {
        player1: {
          marker: 'O',
          status: false
        },
        player2: {
          marker: 'X',
          status: false
        }
      },
      gameStatus: false,
      numTurns: 0
    };
  },
  getInitialBoard: function() {
    return [
      ['', '', ''], 
      ['', '', ''], 
      ['', '', '']
    ]
  },
  resetGame: function() {
    this.setState(this.getInitialState());
  },
  updateSquare: function(clickedSquareX, clickedSquareY) {
    if (this.state.board[clickedSquareX][clickedSquareY] === '') {
      var player1Status = false;
      var player2Status = false;
      
      this.state.numTurns++;
      
      this.state.board[clickedSquareX][clickedSquareY] = this.state.currentPlayer;
      
      var hasGameEnded = checkWinCondition(this.state.board) || this.state.numTurns == 9;
      
      if (checkWinCondition(this.state.board)) {
        if (this.state.currentPlayer == this.state.players.player1.marker)
          player1Status = true;
        else
          player2Status = true;
      }
      
      if (this.state.currentPlayer === this.state.players.player1.marker)
        this.state.currentPlayer = this.state.players.player2.marker;
      else
        this.state.currentPlayer = this.state.players.player1.marker;
      
      this.setState({
        currentPlayer: this.state.currentPlayer,
        board: this.state.board,
        gameStatus: hasGameEnded,
        numTurns: this.state.numTurns,
        players: {
          player1: {
            marker: 'O',
            status: player1Status
          },
          player2: {
            marker: 'X',
            status: player2Status
          }
        }
      });
    }
  },
  render: function() {
    var board = this.state.board;
    var playerFrame = null;
    
    if (this.state.gameStatus) {
      if (this.state.numTurns != 9) {
        playerFrame = (<PlayerFrame playerStatus={this.state.players.player1.status ? "Player 1 Wins!" : "Player 2 Wins!"}
                                   gameStatus={this.state.gameStatus}
                                   resetGame={this.resetGame}/>)
      }
      else {
        playerFrame = (<PlayerFrame playerStatus={"Tie"}
                                   gameStatus={this.state.gameStatus}
                                   resetGame={this.resetGame}/>)
      }
    }
    else {
        playerFrame = (<PlayerFrame playerStatus={this.state.currentPlayer == "O" ? "Player 1 Turn" : "Player 2 Turn"}/>)
    }
    
    return (
      <div>
        <Grid board={board}
              updateSquare={this.updateSquare}
              disabled={this.state.gameStatus}
              />
        {playerFrame}
      </div>
    );
  }
});

ReactDOM.render(<Main/>, document.getElementById("root"));