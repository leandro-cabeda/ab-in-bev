describe('API - Listar Usuários', () => {
  it('Deve listar usuários cadastrados', () => {
    cy.request('GET', 'https://serverest.dev/usuarios').then((response) => {
      expect(response.status).to.eq(200);
      expect(response.body.quantidade).to.be.greaterThan(0);
    });
  });
});
