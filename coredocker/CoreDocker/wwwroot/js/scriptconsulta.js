function _defineProperty(obj, key, value) {if (key in obj) {Object.defineProperty(obj, key, { value: value, enumerable: true, configurable: true, writable: true });} else {obj[key] = value;}return obj;}class App extends React.Component {constructor(...args) {super(...args);_defineProperty(this, "state",
    {
      isLoading: true,
      pedido: [],
      error: null });}


  fetchUsers() {
      fetch(`https://localhost:50001/listar`).
    then(response => response.json()).
    then((data) =>
    this.setState({
      pedido: data,
      isLoading: false })).


    catch(error => this.setState({ error, isLoading: false }));
  }

  componentDidMount() {
    this.fetchUsers();
  }
  render() {
    const { isLoading, pedido, error } = this.state;
    return (
      React.createElement(React.Fragment, null,
      React.createElement("h1", null, "Pedidos"),
      error ? React.createElement("p", null, error.message) : null,
      !isLoading ?
      pedido.map(pedidos => {
        const { objetId, tamanho, sabor,personalizacao,valor_total,tempo_preparo, mesa_register } = pedidos;
        return (
            React.createElement("div", { key: objetId },

          React.createElement(document.getElementById("dt1").innerHTML = sabor),
          React.createElement(document.getElementById("per1").innerHTML = personalizacao),
          React.createElement(document.getElementById("tam1").innerHTML = tamanho),
          React.createElement(document.getElementById("val1").innerHTML = valor_total),
          React.createElement(document.getElementById("tmp1").innerHTML = tempo_preparo),
          React.createElement(document.getElementById("ms1").innerHTML = mesa_register),
         
          React.createElement("hr", null)));

      }) :

      React.createElement("h3", null, "Listando DB...")));



  }}



ReactDOM.render(React.createElement(App, null), document.getElementById("root"));