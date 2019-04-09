import React, { Component } from "react";

class Listar extends Component {
  constructor(){
      super();
      this.state = {
        lista : [],
        nome: "",
        tituloPagina : "Listagem dos desejos"
      }

      this.atualizaEstadoNome = this.atualizaEstadoNome.bind(this);
      this.cadastraTipoEvento = this.adicionarDesejo.bind(this);
  }

  listarDesejos(){
      fetch('http://localhost:5000/api/wishes/SeusDesejos')
        .then(resposta => resposta.json())
        .then(data => this.setState({lista : data}))
        .catch((erro) => console.log(erro))
  }

  componentDidMount(){
      this.listarDesejos();
  }

  atualizaEstadoNome(event){
    this.setState({ nome : event.target.value });
  }

  adicionarDesejo(event){
    event.preventDefault();
    
    fetch('http://localhost:5000/api/wishes',
        {
          method: 'POST',
          body : JSON.stringify({ nome : this.state.nome }),
          headers: {
            "Content-Type" : "application/json"
          }
        })
        .then(resposta => resposta)
        .then(this.listarDesejos())
        .catch(erro => console.log(erro))
  }

  render() {
    return (
      <div>

        <main className="conteudoPrincipal">
          <section className="conteudoPrincipal-cadastro">

            <div className="container" id="conteudoPrincipal-lista">
              <table id="tabela-lista">
                <thead>
                  <tr>
                    <th>#</th>
                    <th>Desejos</th>
                  </tr>
                </thead>
                <tbody>
                    {
                        this.state.lista.map(function(wishes){
                            return (
                                <tr key={wishes.id}>
                                    <td>{wishes.id}</td>
                                    <td>{wishes.wishDescription}</td>
                                </tr>
                            );
                        })
                    }
                </tbody>
              </table>
            </div>

            <div className="container" id="conteudoPrincipal-cadastro">

              <form onSubmit={this.adicionarDesejo}>
                <div className="container">
                  <input
                    type="text"
                    value={this.state.nome}
                    onChange={this.atualizaEstadoNome}
                    id="nome-tipo-evento"
                    placeholder="tipo do evento"
                  />
                  <button className="conteudoPrincipal-btn conteudoPrincipal-btn-cadastro">
                    Cadastrar
                  </button>
                </div>
              </form>
            </div>
          </section>
        </main>

      </div>
    );
  }
}

export default Listar;