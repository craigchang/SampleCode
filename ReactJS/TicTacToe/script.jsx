// Code goes here
'use strict'

function unescapeHtml(str){
  return $('<div/>').html(str).text();
}

function winCondition(board) {
  
  var winCond = 
  
  (board[0][0] == board[0][1] && board[0][1] == board[0][2] && (board[0][0] == "X" || board[0][0] == "O")) ||
  (board[1][0] == board[1][1] && board[1][1] == board[1][2] && (board[1][0] == "X" || board[1][0] == "O")) ||
  (board[2][0] == board[2][1] && board[2][1] == board[2][2] && (board[2][0] == "X" || board[2][0] == "O")) ||
  
  (board[0][0] == board[1][0] && board[1][0] == board[2][0] && (board[0][0] == "X" || board[0][0] == "O")) ||
  (board[0][1] == board[1][1] && board[1][1] == board[2][1] && (board[0][1] == "X" || board[0][1] == "O")) ||
  (board[0][2] == board[1][2] && board[1][2] == board[2][2] && (board[0][2] == "X" || board[0][2] == "O")) ||
  
  (board[0][0] == board[1][1] && board[1][1] == board[2][2] && (board[0][0] == "X" || board[0][0] == "O")) ||
  (board[2][0] == board[1][1] && board[1][1] == board[0][2] && (board[2][0] == "X" || board[2][0] == "O"));
  
  return winCond;
}

var PlayerFrame = React.createClass({
  render: function() {
    var resetButton = null;
    if (this.props.gameStatus)
      resetButton = (<button type="button" 
                             className="btn btn-default reset"
                             onClick={this.props.resetGame}>Reset</button>);
    return (
      <div>
        {this.props.playerStatus}
        <br/>
        {resetButton}
      </div>
    )
  }
});

var Square = React.createClass({
  render: function() {
    var value = this.props.value;
    var xCoord = this.props.xCoord;
    var yCoord = this.props.yCoord;
    var updateSquare = this.props.updateSquare;
    
    return (
      <button type="button" 
              className="btn btn-default"
              onClick={updateSquare.bind(null, xCoord, yCoord)}
              disabled={this.props.disabled}
              >
              {value}
      </button>
    )
  }
});

var Grid = React.createClass({
  getInitialState: function() {
    return {};
  },
  render: function() {
    var board = this.props.board;
    var updateSquare = this.props.updateSquare;
    var disabled = this.props.disabled;

    return (
      <div id="grid">
        <div className="row">
          <Square value={board[0][0]} 
                  xCoord={0}
                  yCoord={0}
                  updateSquare={updateSquare}
                  disabled={disabled}
                  />
          <Square value={board[1][0]} 
                  xCoord={1}
                  yCoord={0}
                  updateSquare={updateSquare}
                  disabled={disabled}
                  />
          <Square value={board[2][0]}
                  xCoord={2}
                  yCoord={0}
                  updateSquare={updateSquare}
                  disabled={disabled}
                  />
        </div>
        <div className="row">
          <Square value={board[0][1]}
                  xCoord={0}
                  yCoord={1}
                  updateSquare={updateSquare}
                  disabled={disabled}
                  />
          <Square value={board[1][1]}
                  xCoord={1}
                  yCoord={1}
                  updateSquare={updateSquare}
                  disabled={disabled}
                  />
          <Square value={board[2][1]}
                  xCoord={2}
                  yCoord={1}
                  updateSquare={updateSquare}
                  disabled={disabled}
                  />
        </div>
        <div className="row">
          <Square value={board[0][2]}
                  xCoord={0}
                  yCoord={2}
                  updateSquare={updateSquare}
                  disabled={disabled}
                  />
          <Square value={board[1][2]}
                  xCoord={1}
                  yCoord={2}
                  updateSquare={updateSquare}
                  disabled={disabled}
                  />
          <Square value={board[2][2]}
                  xCoord={2}
                  yCoord={2}
                  updateSquare={updateSquare}
                  disabled={disabled}
                  />
        </div>
      </div>
    )
  }
});

var Main = React.createClass({
  getInitialState: function() {
    var nbsp = unescapeHtml('&nbsp');
    
    return {
      board: [[nbsp, nbsp, nbsp], [nbsp, nbsp, nbsp], [nbsp, nbsp, nbsp]],
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
  resetGame: function() {
    this.setState(this.getInitialState());
  },
  updatePlayerTurn: function(player) {
    
  },
  updateSquare: function(clickedSquareX, clickedSquareY){
    var stateObj = {};
    var player1Status = false;
    var player2Status = false;
    var hasGameEnded = false;
    
    if (this.state.board[clickedSquareX][clickedSquareY] === unescapeHtml('&nbsp')) {
      
      this.state.numTurns++;
      
      this.state.board[clickedSquareX][clickedSquareY] = this.state.currentPlayer;
      
      hasGameEnded = winCondition(this.state.board) || this.state.numTurns == 9;
      
      if (winCondition(this.state.board)) {
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
    
    console.log(this.state.numTurns);
    
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