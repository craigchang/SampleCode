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