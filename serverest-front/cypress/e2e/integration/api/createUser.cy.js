describe('API - Criar Usuário', () => {
  it('Deve criar um usuário com sucesso', () => {
    cy.request('POST', 'https://serverest.dev/usuarios', {
      nome: 'Novo Usuário',
      email: `user_${Date.now()}@email.com`,
      password: '123456',
      administrador: 'true'
    }).then((response) => {
      expect(response.status).to.eq(201);
      expect(response.body.message).to.eq('Cadastro realizado com sucesso');
    });
  });
});
