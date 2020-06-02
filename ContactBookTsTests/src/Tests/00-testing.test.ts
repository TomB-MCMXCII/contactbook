import { ContactApi } from "../ContactsApi";


describe("Testing", () => {
  it("should clear contacts", async done => {
    const response = await ContactApi.clearContacts();
    expect(response.status).toBe(200);

    done();
  });
});