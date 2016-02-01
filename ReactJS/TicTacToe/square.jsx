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
              disabled={this.props.disabled}>
              {value}
      </button>
    )
  }
});