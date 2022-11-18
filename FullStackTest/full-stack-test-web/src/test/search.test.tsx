import {  render,screen } from "@testing-library/react";
import { Search } from '../components/Search';

test('Test Search Component', () => {
    render(<Search
      onChange={(e: React.ChangeEvent<HTMLInputElement>) => {
      }}
    />);
    const article = screen.getByRole('textbox');
    expect(article).toBeInTheDocument();
  });
