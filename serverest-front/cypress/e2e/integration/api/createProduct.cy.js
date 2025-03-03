describe('API - Criar Produto', () => {
  let token;

  before(() => {
    cy.request({
      method: 'POST',
      url: 'https://serverest.dev/login',
      body: {
        email: 'fulano@qa.com',
        password: 'teste'
      }
    }).then((response) => {
      expect(response.status).to.eq(200);
      token = response.body.authorization;
    });
  });

  it('Deve cadastrar um produto com sucesso', () => {
    cy.request({
      method: 'POST',
      url: 'https://serverest.dev/produtos',
      headers: {
        Authorization: `${token}`
      },
      body: {
        nome: `Produto_${Date.now()}`,
        preco: 150,
        descricao: "Produto de Teste",
        quantidade: 5
      }
    }).then((response) => {
      expect(response.status).to.eq(201);
      expect(response.body).to.have.property('message', 'Cadastro realizado com sucesso');
    });
  });
});

