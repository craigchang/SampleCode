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
        {
          [0,1,2].map(function(col) {
            return (
              <div className="row">
                {
                  [0,1,2].map(function(row) {
                    return (
                      <Square value={board[col][row]} 
                        xCoord={col}
                        yCoord={row}
                        updateSquare={updateSquare}
                        disabled={disabled}/>
                    )
                  })
                }
              </div>
            )
          })
        }
      </div>
    );
  }
});